using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web_api
{
    public class Item
    {

        public Guid ID { get; set; }

        [Required]
        [Range (1, 99)]
        public int level { get; set; }

        [Required]
        [StringLength (9001)]
        [DataType (DataType.Text)]
        public String description { get; set; }

        [DataType (DataType.DateTime)]
        public string creationDate { get; set; }

        public Item () { }
    }

    public class NewItem
    {
        public Guid id = Guid.NewGuid ();

        [Required]
        [Range (1, 99)]
        public int level { get; set; }

        [Required]
        [StringLength (9001)]
        [AllowableStrings]
        public string description { get; set; }

        [CustomModelValidation]
        public string creationDate { get; set; }
        public NewItem ()
        {

        }
    }

    public class ModifiedItem
    {

        public Guid id = Guid.NewGuid ();
        public int level { get; set; }
        public String description { get; set; }

        [CustomModelValidation]
        public string creationDate { get; set; }
        public ModifiedItem ()
        {

        }
    }

}