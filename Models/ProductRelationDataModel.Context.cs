namespace Accounting_of_Goods_ver_2.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ProductRelationDBContext : DbContext
    {
        public ProductRelationDBContext()
            : base("name=ProductRelationDBContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Entrance> Entrances { get; set; }
        public virtual DbSet<Entrance_2> Entrances_2 { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Retail_outlets> Retails_outlets { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
    
        //первый запрос
        public virtual ObjectResult<outputDok_first_Result> outputDok_first()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<outputDok_first_Result>("outputDok_first");
        }
    
        //второй зарос
        public virtual ObjectResult<outputDok_second_Result> outputDok_second(string address)
        {
            var addressParameter = address != null ?
                new ObjectParameter("address", address) :
                new ObjectParameter("address", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<outputDok_second_Result>("outputDok_second", addressParameter);
        }
    
        public virtual int addEntrance(Nullable<int> products_Registration_number, Nullable<int> warehouse_Number, Nullable<int> product_quantity, Nullable<System.DateTime> delivery_date)
        {
            var products_Registration_numberParameter = products_Registration_number.HasValue ?
                new ObjectParameter("Products_Registration_number", products_Registration_number) :
                new ObjectParameter("Products_Registration_number", typeof(int));
    
            var warehouse_NumberParameter = warehouse_Number.HasValue ?
                new ObjectParameter("Warehouse_Number", warehouse_Number) :
                new ObjectParameter("Warehouse_Number", typeof(int));
    
            var product_quantityParameter = product_quantity.HasValue ?
                new ObjectParameter("Product_quantity", product_quantity) :
                new ObjectParameter("Product_quantity", typeof(int));
    
            var delivery_dateParameter = delivery_date.HasValue ?
                new ObjectParameter("delivery_date", delivery_date) :
                new ObjectParameter("delivery_date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addEntrance", products_Registration_numberParameter, warehouse_NumberParameter, product_quantityParameter, delivery_dateParameter);
        }
    
        public virtual int addEntrance2(Nullable<int> products_Registration_number, string retail_outlets_Addressr, Nullable<int> product_quantity)
        {
            var products_Registration_numberParameter = products_Registration_number.HasValue ?
                new ObjectParameter("Products_Registration_number", products_Registration_number) :
                new ObjectParameter("Products_Registration_number", typeof(int));
    
            var retail_outlets_AddressrParameter = retail_outlets_Addressr != null ?
                new ObjectParameter("Retail_outlets_Addressr", retail_outlets_Addressr) :
                new ObjectParameter("Retail_outlets_Addressr", typeof(string));
    
            var product_quantityParameter = product_quantity.HasValue ?
                new ObjectParameter("Product_quantity", product_quantity) :
                new ObjectParameter("Product_quantity", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addEntrance2", products_Registration_numberParameter, retail_outlets_AddressrParameter, product_quantityParameter);
        }
    
        public virtual int addProducts(string name_of_the_company, string units_of_measurement, Nullable<int> cost_of_change)
        {
            var name_of_the_companyParameter = name_of_the_company != null ?
                new ObjectParameter("name_of_the_company", name_of_the_company) :
                new ObjectParameter("name_of_the_company", typeof(string));
    
            var units_of_measurementParameter = units_of_measurement != null ?
                new ObjectParameter("Units_of_measurement", units_of_measurement) :
                new ObjectParameter("Units_of_measurement", typeof(string));
    
            var cost_of_changeParameter = cost_of_change.HasValue ?
                new ObjectParameter("Cost_of_change", cost_of_change) :
                new ObjectParameter("Cost_of_change", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addProducts", name_of_the_companyParameter, units_of_measurementParameter, cost_of_changeParameter);
        }
    
        public virtual int addRetail(string address, string name)
        {
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addRetail", addressParameter, nameParameter);
        }
    
        public virtual int addWarehouse(Nullable<int> number, string full_name_of_the_torekeeper)
        {
            var numberParameter = number.HasValue ?
                new ObjectParameter("Number", number) :
                new ObjectParameter("Number", typeof(int));
    
            var full_name_of_the_torekeeperParameter = full_name_of_the_torekeeper != null ?
                new ObjectParameter("full_name_of_the_torekeeper", full_name_of_the_torekeeper) :
                new ObjectParameter("full_name_of_the_torekeeper", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addWarehouse", numberParameter, full_name_of_the_torekeeperParameter);
        }
    
        public virtual int delEntrance(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delEntrance", iDParameter);
        }
    
        public virtual int delEntrance2(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delEntrance2", iDParameter);
        }
    
        public virtual int delProducts(Nullable<int> registration_number)
        {
            var registration_numberParameter = registration_number.HasValue ?
                new ObjectParameter("Registration_number", registration_number) :
                new ObjectParameter("Registration_number", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delProducts", registration_numberParameter);
        }
    
        public virtual int delRetail(string address)
        {
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delRetail", addressParameter);
        }
    
        public virtual int delWarehouse(Nullable<int> number)
        {
            var numberParameter = number.HasValue ?
                new ObjectParameter("Number", number) :
                new ObjectParameter("Number", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delWarehouse", numberParameter);
        }
    
        public virtual int UpdEntrance(Nullable<int> iD, Nullable<int> product_quantity, Nullable<System.DateTime> delivery_date)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            var product_quantityParameter = product_quantity.HasValue ?
                new ObjectParameter("Product_quantity", product_quantity) :
                new ObjectParameter("Product_quantity", typeof(int));
    
            var delivery_dateParameter = delivery_date.HasValue ?
                new ObjectParameter("delivery_date", delivery_date) :
                new ObjectParameter("delivery_date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdEntrance", iDParameter, product_quantityParameter, delivery_dateParameter);
        }
    
        public virtual int UpdEntrance2(Nullable<int> iD, Nullable<int> product_quantity)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            var product_quantityParameter = product_quantity.HasValue ?
                new ObjectParameter("Product_quantity", product_quantity) :
                new ObjectParameter("Product_quantity", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdEntrance2", iDParameter, product_quantityParameter);
        }
    
        public virtual int UpdProducts(Nullable<int> registration_number, string name_of_the_company, string units_of_measurement, Nullable<int> cost_of_change)
        {
            var registration_numberParameter = registration_number.HasValue ?
                new ObjectParameter("Registration_number", registration_number) :
                new ObjectParameter("Registration_number", typeof(int));
    
            var name_of_the_companyParameter = name_of_the_company != null ?
                new ObjectParameter("name_of_the_company", name_of_the_company) :
                new ObjectParameter("name_of_the_company", typeof(string));
    
            var units_of_measurementParameter = units_of_measurement != null ?
                new ObjectParameter("Units_of_measurement", units_of_measurement) :
                new ObjectParameter("Units_of_measurement", typeof(string));
    
            var cost_of_changeParameter = cost_of_change.HasValue ?
                new ObjectParameter("Cost_of_change", cost_of_change) :
                new ObjectParameter("Cost_of_change", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdProducts", registration_numberParameter, name_of_the_companyParameter, units_of_measurementParameter, cost_of_changeParameter);
        }
    
        public virtual int UpdRetail(string address, string name)
        {
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdRetail", addressParameter, nameParameter);
        }
    
        public virtual int UpdWarehouse(Nullable<int> number, string full_name_of_the_torekeeper)
        {
            var numberParameter = number.HasValue ?
                new ObjectParameter("Number", number) :
                new ObjectParameter("Number", typeof(int));
    
            var full_name_of_the_torekeeperParameter = full_name_of_the_torekeeper != null ?
                new ObjectParameter("full_name_of_the_torekeeper", full_name_of_the_torekeeper) :
                new ObjectParameter("full_name_of_the_torekeeper", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdWarehouse", numberParameter, full_name_of_the_torekeeperParameter);
        }

        public System.Data.Entity.DbSet<Accounting_of_Goods_ver_2.Models.outputDok_second_Result> outputDok_second_Result { get; set; }
    }
}
