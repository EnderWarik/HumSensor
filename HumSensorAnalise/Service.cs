using HumSensorAnalise.Models;
namespace HumSensorAnalise
{
    public class Service
    {
        public List<HumSensor> results = new List<HumSensor>();
        public List<HumSensor> StaticticLastFiveMinute()
        {

            var dt = DateTime.Now.Subtract(new TimeSpan(0, 0, 5, 0));
            using (ApplicationContext db = new ApplicationContext())
            {
                this.results = (from HumSensor in db.humSensor
                                 where HumSensor.dtAdd >= dt.ToUniversalTime()
                                select HumSensor).ToList();
            }
            return results;
        }
}
}




