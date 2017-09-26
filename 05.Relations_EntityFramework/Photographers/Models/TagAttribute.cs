using System.ComponentModel.DataAnnotations;

namespace Photographers.Models
{
  public  class TagAttribute :ValidationAttribute
    {
        public override bool IsValid(object tag)
        {
            string tagValue = (string)tag;
            if (!tagValue.StartsWith("#"))
            {
                return false;
            }
            if (tagValue.Contains(" "))
            {
                return false;
            }
            if (tagValue.Length>20)
            {
                return false;
            }
            return true;
        }
    }
}
