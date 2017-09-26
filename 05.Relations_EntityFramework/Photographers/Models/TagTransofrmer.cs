
namespace Photographers.Models
{
  public class TagTransofrmer
    {
        public static string Transform(object tag)
        {
            string tagValue = (string)tag;
            tagValue = tagValue.Replace(" ",string.Empty);//remove all spaces

            if (tagValue.Substring(0, 1) != "#")
            {
                tagValue = "#" + tagValue;
            }
            if (tagValue.Length > 20)
            {
                tagValue = tagValue.Substring(0, 20);
            }            
            return tagValue;
        }
    }
}
