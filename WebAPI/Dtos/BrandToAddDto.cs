using Domain.Extensions.String;

namespace WebAPI.Dtos
{
    public class BrandToAddDto
    {
        private string _name;

        public string Name
        {
            get { return _name.FirstCharToUpper(); }
            set { _name = value; }
        }
    }
}
