using System.Collections.Generic;
using StarWarsKb.Infrastructure.Model;

namespace StarWarsKb.Back.Model
{
    public interface IReportGenerator
    {
        IList<ReportEntity> GetReport();
    }
}