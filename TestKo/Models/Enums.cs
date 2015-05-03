using System.ComponentModel;

namespace TestKo.Models
{
    public enum FoodCategoryEnum
    {
        Veggie = 1,
        Meat = 2,
        Grain = 3
    }

    public enum BookCategoryEnum
    {
        Comedy = 0,
        Drama = 1
    }

    public enum OptionEnum
    {
        [Description("First")]
        FirstOption = 1,
        [Description("Second")]
        SecondOption = 2,
        [Description("Third")]
        ThirdOption = 3
    }

    public enum StateCode
    {
        NotSet =0, AL = 1, AK = 2, AZ = 3, AR = 4, CA = 5
    }
}