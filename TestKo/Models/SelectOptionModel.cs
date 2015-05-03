using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace TestKo.Models
{
    public class SelectOptionModel
    {
        private DateTime? today = DateTime.Now;

        public SelectOptionModel()
        {
            Book = new SubSelectModel();
            Food = new ThirdModel();
            MoreGuests = new List<Guest>();
        }

        public bool Eligible { get; set; }

        [Display(Name = "Guest Name"), Required]
        public string Name { get; set; }

        public StateCode State { get; set; }

        public IList<Guest> MoreGuests { get; set; }

        public OptionEnum SelectedOption { get; set; }

        public SubSelectModel Book { get; set; }

        public ThirdModel Food { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? Date
        {
            get
            {
                return today;
            }
            set
            {
                today = value;
            }
        }

        public IEnumerable<SelectListItem> AvailableOptions
        {
            get
            {
                return Enum.GetValues(typeof(OptionEnum)).Cast<OptionEnum>()
                .Select(x => new SelectListItem
                {
                    Text = x.ToString(),
                    Value = x.ToString()
                });
            }
        }
    }

    public class SubSelectModel
    {
        public string Name { get; set; }
        public decimal? UnitPrice { get; set; }
        public BookCategoryEnum? Category { get; set; }
    }

    public class ThirdModel
    {
        [Display(Name = "Food name")]
        public string FoodName { get; set; }
        public decimal? FoodWeight { get; set; }
        public FoodCategoryEnum? Category { get; set; }
    }
}