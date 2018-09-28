using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management
{
    class Hotel
    {
            long hotelId;
            string briefNote;
            string hotelName;
            string photoUR;
            int starRanking;

          public void set()
             {
            this.hotelId = Convert.ToInt64(Console.ReadLine());
            this.briefNote = Console.ReadLine();
            this.hotelName = Console.ReadLine();
            this.photoUR = Console.ReadLine();
            this.starRanking = Convert.ToInt32(Console.ReadLine());
            }

           public long getID()
        {
            return this.hotelId;
        }

        public int getRank()
        {
            return this.starRanking;
        }

        public string getNote()
        {
            return this.briefNote;
        }

        public string getPhoto()
        {
            return this.photoUR;
        }

        public string getName()
        {
            return this.hotelName;
        }
    }   

    class HotelMgr
    {
       public Hotel storeData(Hotel h)
        {
            h.set();
            return h;
        }

        public void showData(Hotel h)
        {
            Console.WriteLine("{0}  {1}  {2}  {3}  {4}", h.getID(), h.getName(), h.getNote(), h.getPhoto(), h.getRank());
        }
    }

    class TestMain
    {
        public static void Main(string []args)
        {
            Hotel h = new Hotel();
            HotelMgr hm = new HotelMgr();
            hm.storeData(h);
            hm.showData(h);

            Console.ReadKey();
        }
    }
}
