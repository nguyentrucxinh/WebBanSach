﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vinabook.Models;

namespace Vinabook.Controllers
{
    public class SachController : Controller
    {
        // GET: Sach
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public PartialViewResult SachMoiPartial()
        {
            var lstSachMoi = db.Saches.Take(10).ToList();
            return PartialView(lstSachMoi);
        }
        public ViewResult Sach()
        {
            var lstSach = db.Saches.Take(20).ToList();
            return View(lstSach);
        }
        public ViewResult SachTheoChuDe(int machude=1)
        {
            
            var lstSach = db.Saches.Where(n => n.MaChuDe == machude).Take(10).ToList();
            ViewBag.TenChuDe = db.ChuDes.Single(n => n.MaChuDe == machude).TenChuDe;
            return View(lstSach);
        } 
        public ViewResult SachTheoNhaXuatBan(int manxb=1)
        {
            ViewBag.NhaXuatBan = db.NhaXuatBans.Single(n => n.MaNXB == manxb).TenNXB;
            var lstSach = db.Saches.Where(n => n.MaNXB == manxb).Take(10).ToList();
            return View(lstSach);
        }
        public PartialViewResult SachTiengAnhPartial()
        {
            var lstSachAV = db.Saches.Where(n => n.MaChuDe == 2).Take(3).ToList();
            return PartialView(lstSachAV);
        }
        public PartialViewResult SachITPartial()
        {
            var lstSachIT = db.Saches.Where(n => n.MaChuDe == 1).Take(3).ToList();
            return PartialView(lstSachIT);
        }
        public PartialViewResult SachPhatGiaoPartial()
        {
            var lstSachPG = db.Saches.Where(n => n.MaChuDe == 3).Take(3).ToList();
            return PartialView(lstSachPG);
        }
        public ViewResult XemChiTiet(int MaSach = 0)
        {
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == MaSach);
            if (sach == null)
            {
                //Trả về trang báo lỗi 
                Response.StatusCode = 404;
                return null;
            }
            //ChuDe cd = db.ChuDes.Single(n => n.MaChuDe == sach.MaChuDe);
            //ViewBag.TenCD = cd.TenChuDe;
            ViewBag.TenChuDe = db.ChuDes.Single(n => n.MaChuDe == sach.MaChuDe).TenChuDe;
            ViewBag.NhaXuatBan = db.NhaXuatBans.Single(n => n.MaNXB == sach.MaNXB).TenNXB;
            return View(sach);
        }
        public PartialViewResult SachCungChuDePartial()
        {

            return PartialView();
        }
        public PartialViewResult SachGanDayPartial()
        {
            var lstSachMoi = db.Saches.Take(10).ToList();
            return PartialView(lstSachMoi);
        }
    }
}