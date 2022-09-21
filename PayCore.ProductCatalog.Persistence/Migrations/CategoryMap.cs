using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PayCore.ProductCatalog.Data.Entities;


namespace PayCore.ProductCatalog.Repository.Migrations
{
    public class CategoryMap:ClassMapping<Category>
    {
        public CategoryMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });


            Property(b => b.CategoryName, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Bag(category => category.Products, map => map.Key(k => k.Column("CategoryId")), rel => rel.OneToMany());

            Table("category");
        }
    }
}

