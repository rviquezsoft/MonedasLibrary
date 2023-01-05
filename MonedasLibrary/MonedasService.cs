﻿using System;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MonedasLibrary
{
    /// <summary>
    /// El código muestra la definición de la clase MonedasService, que tiene dos métodos públicos: GetCurrencies y GetCurrency.
    /// El método GetCurrencies devuelve una enumeración de objetos RegionInfo, que representan regiones geográficas y culturales en el sistema.Para obtener esta enumeración, primero se obtienen todas las culturas específicas del sistema usando el método GetCultures de la clase CultureInfo, y luego se itera sobre cada una de ellas para crear un objeto RegionInfo para cada cultura.Si la moneda de la región tiene un código ISO (es decir, si la propiedad ISOCurrencySymbol del objeto RegionInfo no es null o una cadena vacía), se devuelve el objeto RegionInfo para esa región.
    /// El método GetCurrency devuelve un objeto RegionInfo para una región específica, dada su código ISO. Si el código ISO proporcionado es null o una cadena vacía, se devuelve null. De lo contrario, se obtiene una enumeración de todas las regiones del sistema usando el método GetCurrencies, y se devuelve el primer elemento de la enumeración cuyo código ISO (propiedad ISOCurrencySymbol del objeto RegionInfo) sea igual al código ISO proporcionado, ignorando mayúsculas y minúsculas.Si no se encuentra ningún elemento que cumpla esta condición, se devuelve null.
    /// </summary>
	public class MonedasService : IMonedasService
    {
        /// <summary>
        /// El método GetCurrencies devuelve una enumeración de objetos RegionInfo, que representan regiones geográficas y culturales en el sistema. Para obtener esta enumeración, primero se obtienen todas las culturas específicas del sistema usando el método GetCultures de la clase CultureInfo, y luego se itera sobre cada una de ellas para crear un objeto RegionInfo para cada cultura. Si la moneda de la región tiene un código ISO (es decir, si la propiedad ISOCurrencySymbol del objeto RegionInfo no es null o una cadena vacía), se devuelve el objeto RegionInfo para esa región.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RegionInfo> GetCurrencies()
        {
            var culturas = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (var cultura in culturas)
            {
                var region = new RegionInfo(cultura.Name);
                if (!string.IsNullOrEmpty(region.ISOCurrencySymbol))
                {
                    yield return region;
                }
            }
        }

        /// <summary>
        /// El método GetCurrency devuelve un objeto RegionInfo para una región específica, dada su código ISO. Si el código ISO proporcionado es null o una cadena vacía, se devuelve null. De lo contrario, se obtiene una enumeración de todas las regiones del sistema usando el método GetCurrencies, y se devuelve el primer elemento de la enumeración cuyo código ISO (propiedad ISOCurrencySymbol del objeto RegionInfo) sea igual al código ISO proporcionado, ignorando mayúsculas y minúsculas. Si no se encuentra ningún elemento que cumpla esta condición, se devuelve null.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public RegionInfo GetCurrency(string code)
        {

            if (string.IsNullOrWhiteSpace(code))
            {
                return null;
            }
            IEnumerable<RegionInfo> regionInfos = GetCurrencies();

            return regionInfos.Where(x => x.ISOCurrencySymbol.ToUpperInvariant() == code.ToUpperInvariant()).FirstOrDefault();
        }
    }
}

