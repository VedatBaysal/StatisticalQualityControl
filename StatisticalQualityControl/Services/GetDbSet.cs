using StatisticalQualityControl.Facade;
using StatisticalQualityControl.Models;

namespace StatisticalQualityControl.Services
{
    public static class GetDbSet
    {
        private static Crud<Manufacture> _crudManufacture;
        private static Crud<ManufactureMistake> _crudManufactureMistake;
        private static Crud<Material> _crudMaterial;
        private static Crud<MaterialMeasuresOfProduct> _crudMaterialMeasuresOfProduct;
        private static Crud<Measurement> _crudMeasurement;
        private static Crud<MeasuresOfManufactureProduct> _crudMeasuresOfManufactureProduct;
        private static Crud<Mistake> _crudMistake;
        private static Crud<MistakeOccurenceFactorDetail> _crudMistakeOccurenceFactorDetail;
        private static Crud<MistakeOccurrenceFactor> _crudMistakeOccurrenceFactor;
        private static Crud<Product> _crudProduct;
        private static Crud<ProductMaterial> _crudProductMaterial;
        private static Crud<Role> _crudRole;
        private static Crud<Sector> _crudSector;
        private static Crud<Staff> _crudStaff;
        private static Crud<StaffLeaveDay> _crudStaffLeaveDay;
        private static Crud<User> _crudUser;

        
        public static Crud<Manufacture> CrudManufacture => _crudManufacture ?? (_crudManufacture = new Crud<Manufacture>());

        public static Crud<ManufactureMistake> CrudManufactureMistake => _crudManufactureMistake ?? (_crudManufactureMistake = new Crud<ManufactureMistake>());

        public static Crud<Material> CrudMaterial => _crudMaterial ?? (_crudMaterial = new Crud<Material>());

        public static Crud<MaterialMeasuresOfProduct> CrudMaterialMeasuresOfProduct => _crudMaterialMeasuresOfProduct ?? (_crudMaterialMeasuresOfProduct = new Crud<MaterialMeasuresOfProduct>());

        public static Crud<Measurement> CrudMeasurement => _crudMeasurement ?? (_crudMeasurement = new Crud<Measurement>());

        public static Crud<MeasuresOfManufactureProduct> CrudMeasuresOfManufactureProduct => _crudMeasuresOfManufactureProduct ?? (_crudMeasuresOfManufactureProduct = new Crud<MeasuresOfManufactureProduct>());

        public static Crud<Mistake> CrudMistake => _crudMistake ?? (_crudMistake = new Crud<Mistake>());

        public static Crud<MistakeOccurenceFactorDetail> CrudMistakeOccurenceFactorDetail => _crudMistakeOccurenceFactorDetail ?? (_crudMistakeOccurenceFactorDetail = new Crud<MistakeOccurenceFactorDetail>());

        public static Crud<MistakeOccurrenceFactor> CrudMistakeOccurrenceFactor => _crudMistakeOccurrenceFactor ?? (_crudMistakeOccurrenceFactor = new Crud<MistakeOccurrenceFactor>());

        public static Crud<Product> CrudProduct => _crudProduct ?? (_crudProduct = new Crud<Product>());

        public static Crud<ProductMaterial> CrudProductMaterial => _crudProductMaterial ?? (_crudProductMaterial = new Crud<ProductMaterial>());

        public static Crud<Role> CrudRole => _crudRole ?? (_crudRole = new Crud<Role>());

        public static Crud<Sector> CrudSector => _crudSector ?? (_crudSector = new Crud<Sector>());

        public static Crud<Staff> CrudStaff => _crudStaff ?? (_crudStaff = new Crud<Staff>());

        public static Crud<StaffLeaveDay> CrudStaffLeaveDay => _crudStaffLeaveDay ?? (_crudStaffLeaveDay = new Crud<StaffLeaveDay>());

        public static Crud<User> CrudUser => _crudUser ?? (_crudUser = new Crud<User>());
    }
}