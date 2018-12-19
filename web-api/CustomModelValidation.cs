using System;
using System.ComponentModel.DataAnnotations;

namespace web_api

{
    sealed public class CustomModelValidation : ValidationAttribute
    {
        DateTime DT;
        public override bool IsValid (object value)
        {
            if (value != null)
            {
                //DT = DateTime.Parse (value.ToString ());
                try
                {
                    if (!DateTime.TryParse (value.ToString (), out DateTime result))
                    {
                        throw new FormatException ("Parsing failed!");
                    }
                    else
                    {
                        DT = result;
                    }
                }
                catch (FormatException arg)
                {
                    Console.WriteLine (arg);
                }
                if (DT.Date > DateTime.Now)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}

sealed public class AllowableStrings : ValidationAttribute
{
    public override bool IsValid (object value)
    {
        if (value != null)
        {
            if (value.ToString () == "Sword" || value.ToString () == "Mace" || value.ToString () == "Axe")
            {
                return true;
            }
            return false;
        }
        return false;
    }
}