using ErdaldanisEDU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace ErdaldanisEDU.Controllers
{
    
    [ControlLogin]
    public class YoneticiController : Controller
    {
        ErdaldanisEDUdb erdaldanis = new ErdaldanisEDUdb();
        public ActionResult Anasayfa()
        {
            return View();

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Egitmenler()
        {
            List<EgitmenEkle> kayitListe = erdaldanis.EgitmenEkle.ToList();
            return View(kayitListe);
           
        }

        public ActionResult EgitmenEkle()
        {


            return View();
            

        }
        
        
        [HttpPost]
        public ActionResult EgitmenEkle(EgitmenEkle egitmen)
        {
            EgitmenEkle kayit = new EgitmenEkle();
            kayit.adi = egitmen.adi;
            kayit.soyadi = egitmen.soyadi;
            kayit.bolum = egitmen.bolum;
            kayit.username = egitmen.username;
            kayit.email = egitmen.email;
            kayit.password = egitmen.password;
            kayit.fakulte = egitmen.fakulte;

            erdaldanis.EgitmenEkle.Add(kayit);
            erdaldanis.SaveChanges();
            ViewBag.sonuc = "Kayıt Yapıldı";
            return View();

        }
       
        public ActionResult EgitmenDuzenle(int? id)
        {
            EgitmenEkle kayit = erdaldanis.EgitmenEkle.Where(k => k.egitmenId == id).SingleOrDefault();

            EgitmenEkle egitmen = new EgitmenEkle()
            {
                egitmenId = kayit.egitmenId,
                adi = kayit.adi,
                soyadi = kayit.soyadi,
                bolum = kayit.bolum,
                username = kayit.username,
                email = kayit.email,
                password = kayit.password,
                fakulte = kayit.fakulte
            };


            return View(egitmen);

        }
        
        public ActionResult EgitmenSil(int? id)
        {
            EgitmenEkle kayit = erdaldanis.EgitmenEkle.Where(k => k.egitmenId == id).SingleOrDefault();

            erdaldanis.EgitmenEkle.Remove(kayit);
            erdaldanis.SaveChanges();
            return RedirectToAction("Egitmenler");
        }

        [HttpPost]
        public ActionResult EgitmenDuzenle(EgitmenEkle ekle)
        {
            EgitmenEkle kayit = erdaldanis.EgitmenEkle.Where(k => k.egitmenId == ekle.egitmenId).SingleOrDefault();

            kayit.adi = ekle.adi;
            kayit.soyadi = ekle.soyadi;
            kayit.bolum = ekle.bolum;
            kayit.username = ekle.username;
            kayit.email = ekle.email;
            kayit.password = ekle.password;
            kayit.fakulte = ekle.fakulte;
            erdaldanis.SaveChanges();
            return View();
        }









    }
}