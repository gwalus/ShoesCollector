using Domain.Extensions.String;

namespace WebAPI.Dtos
{
    public class ProductSourceToAddDto
    {
        private string _name;

        public string Name
        {
            get { return _name.FirstCharToUpper(); }
            set { _name = value; }
        }
    }
}
