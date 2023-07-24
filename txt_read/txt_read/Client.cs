using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using txt_read.Modifiers;

namespace txt_read
{
    public class Client
    {
        private readonly IEnumerable<Modifier> _modifiers;
        private Queue<string> _data;
        private readonly string _resPath = "Results/res-" + DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        public readonly int Total;

        public int Done { get 
            {
                lock (_data)
                    return Total - _data.Count;
            } }

        public Client(IEnumerable<Modifier> modifiers, IEnumerable<string> data)
        {
            Total = data.Count();
            _modifiers = modifiers;
            _data = new Queue<string>(data);
            Directory.CreateDirectory(_resPath);
        }

        public void Start(int threadsAmount)
        {
            for (int i = 0; i < threadsAmount; i++)
            {
                CreateThread();
            }
        }

        public void CreateThread()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    string item;
                    lock (_data)
                    {
                        if (!_data.Any())
                            return;
                        item = _data.Dequeue();
                    }
                    var logPass = item.Split(':');
                    if (logPass.Length < 2)
                        continue;



                    foreach (var mod in _modifiers)
                    {
                     
                        var res = mod.Modify(logPass[1]);

                        if (res is not null)
                        {
                            lock (mod)
                            {
                                File.AppendAllLines(_resPath + "/" + mod.Name + ".txt", res.Select(w => logPass[0] + ":" + w));
                            }
                           
                        }
                         
                    }
                   

                }
            });
        }
        
    }
}
