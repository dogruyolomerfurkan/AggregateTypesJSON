using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Entities;

namespace WebAPI.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.OwnsOne(user => user.Address, ownedNavigationBuilder =>
        {
            ownedNavigationBuilder.ToJson();
        });
        builder.OwnsMany(user => user.Orders, ownedNavigationBuilder =>
        {
            ownedNavigationBuilder.ToJson();
        });
    }
}
