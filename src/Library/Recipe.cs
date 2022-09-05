//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;
using System.Text;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public StringBuilder RecipeText() //Ya no imprime, sino que devuelve un string con lo que se debe imprimir
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                str.AppendLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            str.AppendLine($"El costo total de producción de un producto es {GetProductionCost()}");
            return str;
        }

        //Sumatoria del costo de cada paso. 
        //Se puso en esta clase porque es la que conoce todos los pasos de una receta, y en cada uno de ellos esta toda la información
        //necesaria para calcular costos, basandonos en el patrón Expert
        public double GetProductionCost(){
            double costoTotal=0;
            foreach (Step step in this.steps){
                costoTotal+=step.StepCostUnit();
            }
            return costoTotal;
        }
    }
}