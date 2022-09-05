using System;
using System.Collections;
using System.Linq;


namespace Full_GRASP_And_SOLID.Library{
    public class Catalog{
        
        private static ArrayList productCatalog = new ArrayList();

        private static ArrayList equipmentCatalog= new ArrayList();

        public static void AddProductToCatalog(string description, double unitCost)
        {
            productCatalog.Add(new Product(description, unitCost));
        }

        public static void AddEquipmentToCatalog(string description, double hourlyCost)
        {
            equipmentCatalog.Add(new Equipment(description, hourlyCost));
        }

        public static Product ProductAt(int index)
        {
            return productCatalog[index] as Product;
        }

        public static Equipment EquipmentAt(int index)
        {
            return equipmentCatalog[index] as Equipment;
        }

        public static Product GetProduct(string description)
        {
            var query = from Product product in productCatalog where product.Description == description select product;
            return query.FirstOrDefault();
        }

        public static Equipment GetEquipment(string description)
        {
            var query = from Equipment equipment in equipmentCatalog where equipment.Description == description select equipment;
            return query.FirstOrDefault();
        }
    }
}