using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects.DataClasses;
using System.Reflection;

namespace Backend.Models
{
    
    public static class Utilities
    {

        public static void ForEach<T>(this IQueryable<T> collection, Action<T> action)
            where T : EntityObject
        {

            foreach (T entry in collection)
            {
                action(entry);
            }

        }

        public static T LoadAs<R, T>(this EntityReference<R> reference)
            where T : class, new()
            where R : EntityObject
        {

            if (reference == null)
                return null;

            reference.Load();
            return reference.Value.CopyProperties<T>();

        }


        public static T CopyProperties<T>(this object source)
            where T : class, new()
        {

            //verifica se o objeto é nulo
            if (source == null)
                return null;

            //retorna propriedades do tipo que existem no objeto
            PropertyInfo[] sourceProperties = source.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).OrderBy(entry => entry.Name).ToArray();
            PropertyInfo[] targetProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(entry => sourceProperties.Any(prop => prop.Name == entry.Name)).OrderBy(entry => entry.Name).ToArray();
            sourceProperties = sourceProperties.Where(entry => targetProperties.Any(prop => prop.Name == entry.Name)).OrderBy(entry => entry.Name).ToArray();

            // inicializa objeto
            T target = new T();

            // enumera propriedades e copia valores
            for (int index = 0; index < targetProperties.Length; index++)
            {
                targetProperties[index].SetValue(target, sourceProperties[index].GetValue(source, null), null);
            }

            // retorna novo objeto
            return target;

        }

        public struct CalculoDistancia
        {

            public double RadianosOrigem;
            public double RadianosDestino;
            public double RadianosTheta;
            public double Seno;
            public double Coseno;
            public double Angulo;
            public double Milhas;
            public double Kilometros;

        }

        public static CalculoDistancia Distance(double lat1, double lon1, double lat2, double lon2)
        {

            CalculoDistancia calculo = new CalculoDistancia();
            calculo.RadianosOrigem = Math.PI * lat1 / 180;
            calculo.RadianosDestino = Math.PI * lat2 / 180;
            calculo.RadianosTheta = Math.PI * (lon1 - lon2) / 180;

            calculo.Seno = Math.Sin(calculo.RadianosOrigem) * Math.Sin(calculo.RadianosDestino);
            calculo.Coseno = Math.Cos(calculo.RadianosOrigem) * Math.Cos(calculo.RadianosDestino) * Math.Cos(calculo.RadianosTheta);
            calculo.Angulo = Math.Acos(calculo.Seno + calculo.Coseno);
            calculo.Milhas = calculo.Angulo * 180 / Math.PI * 60 * 1.1515;
            calculo.Kilometros = calculo.Milhas * 1.609344;

            return calculo;

        }

    }

}