using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PLC.Data;
using plc.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PLC.Controllers
{
    public class plCasController : Controller
    {
        private readonly PLCContext _context;

        public plCasController(PLCContext context)
        {
            _context = context;
        }

        // GET: plCas
        public async Task<IActionResult> Index(string searchString, int? searchRating)
        {
            var plCas = _context.plCa.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                plCas = plCas.Where(p => p.TenCa.Contains(searchString));
            }

            if (searchRating.HasValue)
            {
                plCas = plCas.Where(p => p.DanhGia == searchRating.Value);
            }

            return View(await plCas.ToListAsync());
        }

        // GET: plCas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var plCa = await _context.plCa.FirstOrDefaultAsync(m => m.Id == id);
            if (plCa == null) return NotFound();

            return View(plCa);
        }

        // GET: plCas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: plCas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenCa,MoTa,DanhGia,LoaiNuoc,KichThuoc,MauSac,ThoiGianSinhTon,HinhAnh")] plCa plCa)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(plCa.HinhAnh) && !IsValidUrl(plCa.HinhAnh))
                {
                    ModelState.AddModelError("HinhAnh", "The image URL is invalid.");
                    return View(plCa);
                }

                _context.Add(plCa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plCa);
        }

        // GET: plCas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var plCa = await _context.plCa.FindAsync(id);
            if (plCa == null) return NotFound();

            return View(plCa);
        }

        // POST: plCas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenCa,MoTa,DanhGia,LoaiNuoc,KichThuoc,MauSac,ThoiGianSinhTon,HinhAnh")] plCa plCa)
        {
            if (id != plCa.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    if (!string.IsNullOrEmpty(plCa.HinhAnh) && !IsValidUrl(plCa.HinhAnh))
                    {
                        ModelState.AddModelError("HinhAnh", "The image URL is invalid.");
                        return View(plCa);
                    }

                    _context.Update(plCa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!plCaExists(plCa.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while saving the data.");
                    return View(plCa);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(plCa);
        }

        // GET: plCas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var plCa = await _context.plCa.FirstOrDefaultAsync(m => m.Id == id);
            if (plCa == null) return NotFound();

            return View(plCa);
        }

        // POST: plCas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plCa = await _context.plCa.FindAsync(id);
            if (plCa != null)
            {
                _context.plCa.Remove(plCa);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: plCas/GetImage/5
        public async Task<IActionResult> GetImage(int id)
        {
            var plCa = await _context.plCa.FirstOrDefaultAsync(p => p.Id == id);
            if (plCa == null || string.IsNullOrEmpty(plCa.HinhAnh))
            {
                return NotFound();
            }

            return Redirect(plCa.HinhAnh);
        }

        private bool plCaExists(int id)
        {
            return _context.plCa.Any(e => e.Id == id);
        }

        // Simple URL validation
        private bool IsValidUrl(string url)
        {
            Uri uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
