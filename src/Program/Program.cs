//-------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;
using System.Linq;
using Full_GRASP_And_SOLID.Library;
using System.Text;

namespace Full_GRASP_And_SOLID
{
    public class Program
    {

        //Se movió todo lo relacionado a Catálogos a una clase creada para ello, enfocándonos en aplicar SRP
        public static void Main(string[] args)
        {
            PopulateCatalogs();
            string txtRecipe;

            Recipe recipe = new Recipe();
            recipe.FinalProduct = Catalog.GetProduct("Café con leche");
            recipe.AddStep(new Step(Catalog.GetProduct("Café"), 100, Catalog.GetEquipment("Cafetera"), 120));
            recipe.AddStep(new Step(Catalog.GetProduct("Leche"), 200, Catalog.GetEquipment("Hervidor"), 60));
            //Aplique SRP para quitarle responsabilidades a Recipe, ahora devuelve el texto a imprimir, no lo imprime
            //De esta manera, se puede imprimir en cualquier medio que se quiera
            txtRecipe= recipe.RecipeText().ToString();
            ConsolePrinter printer = new ConsolePrinter(txtRecipe);

        }

        //Este método sí se dejó, ya que solo agrega y es algo que debería poder manejar el usuario desde aquí 
        private static void PopulateCatalogs()
        {
            Catalog.AddProductToCatalog("Café", 100);
            Catalog.AddProductToCatalog("Leche", 200);
            Catalog.AddProductToCatalog("Café con leche", 300);

            Catalog.AddEquipmentToCatalog("Cafetera", 1000);
            Catalog.AddEquipmentToCatalog("Hervidor", 2000);
        }

    }
}
