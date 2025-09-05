using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        ConfigureMenuSectionsTable(builder);
        ConfigureMenuDinnersTable(builder);
        ConfigureMenuReviewsTable(builder);
    }

    private void ConfigureMenuReviewsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(menu => menu.MenuReviews, reviewBuilder =>
        {
            reviewBuilder.ToTable("MenuReviewIds");
            reviewBuilder.WithOwner().HasForeignKey("MenuId");
            reviewBuilder.HasKey("Id");

            reviewBuilder.Property(review => review.Value)
                .HasColumnName("MenuReviewId")
                .ValueGeneratedNever(); 
        });

        builder.Metadata.FindNavigation(nameof(Menu.MenuReviews))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuDinnersTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(menu => menu.Dinners, dinnerBuilder =>
        {
            dinnerBuilder.ToTable("MenuDinnerIds");
            dinnerBuilder.WithOwner().HasForeignKey("MenuId");
            dinnerBuilder.HasKey("Id");

            dinnerBuilder.Property(dinner => dinner.Value)
                .HasColumnName("DinnerId")
                .ValueGeneratedNever(); 
        });

        builder.Metadata.FindNavigation(nameof(Menu.Dinners))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(menu => menu.Sections, sectionBuilder =>
        {
            sectionBuilder.ToTable("MenuSections");

            sectionBuilder.WithOwner().HasForeignKey("MenuId");
            sectionBuilder.HasKey("Id", "MenuId");

            sectionBuilder.Property(section => section.Id)
                .HasColumnName("Id")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuSectionId.Create(value));

            sectionBuilder.Property(section => section.Name)
                .HasMaxLength(100);

            sectionBuilder.Property(section => section.Description)
                .HasMaxLength(1000);

            sectionBuilder.OwnsMany(section => section.MenuItems, itemBuilder =>
            {
                itemBuilder.ToTable("MenuItems");

                itemBuilder.WithOwner().HasForeignKey("MenuSectionId", "MenuId");
                itemBuilder.HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuId");

                itemBuilder.Property(item => item.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => MenuItemId.Create(value));

                itemBuilder.Property(item => item.Name)
                    .HasMaxLength(100);

                itemBuilder.Property(item => item.Description)
                    .HasMaxLength(1000);
            });

            sectionBuilder.Navigation(section => section.MenuItems)
                .Metadata.SetField("_menuItems");

            sectionBuilder.Navigation(section => section.MenuItems)
                .UsePropertyAccessMode(PropertyAccessMode.Field); 
        });

        builder.Metadata.FindNavigation(nameof(Menu.Sections))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MenuId.Create(value));

        builder.Property(m => m.Name)
            .HasMaxLength(100);

        builder.Property(m => m.Description)
            .HasMaxLength(1000);

        builder.Property(m => m.AverageRating);

        builder.Property(m => m.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value));
    }
}