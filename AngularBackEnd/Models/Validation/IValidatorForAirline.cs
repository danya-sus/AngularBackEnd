using System.Collections.Generic;

namespace AngularBackEnd.Models.Validation
{
    public interface IValidatorForAirline
    {
        public void Validation(IEnumerable<AllData> models, string airlineCode);
    }
}
