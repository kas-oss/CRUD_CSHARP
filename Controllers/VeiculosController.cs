using CRUD_CSHARP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_CSHARP.Controllers
{
    public class VeiculosController : Controller
    {
        private static List<Veiculo> _veiculos = new List<Veiculo>()
        {
            new Veiculo
            {
                Id = 1,
                Modelo = "HB20",
                Marca = "Hyundai",
                Placa = "LUC-0172",
                Ano = 2020
            },
            new Veiculo
            {
                Id = 2,
                Modelo = "Onix",
                Marca = "Chevrolet",
                Placa = "PAZ-0666",
                Ano = 2022
            }
        };

        private static int _proximoId = 3;

        public IActionResult Index()
        {
            return View(_veiculos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                veiculo.Id = _proximoId++;
                _veiculos.Add(veiculo);
                return RedirectToAction(nameof(Index));
            }
            return View(veiculo);
        }

        public IActionResult Edit(int id)
        {
            var veiculo = _veiculos.FirstOrDefault(v => v.Id == id);
            if (veiculo == null) return NotFound();
            return View(veiculo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Veiculo veiculoAtualizado)
        {
            var veiculoExistente = _veiculos.FirstOrDefault(v => v.Id == id);
            if (veiculoExistente == null) return NotFound();

            if (ModelState.IsValid)
            {
                veiculoExistente.Modelo = veiculoAtualizado.Modelo;
                veiculoExistente.Marca = veiculoAtualizado.Marca;
                veiculoExistente.Placa = veiculoAtualizado.Placa;
                veiculoExistente.Ano = veiculoAtualizado.Ano;

                return RedirectToAction(nameof(Index));
            }
            return View(veiculoAtualizado);
        }

        public IActionResult Delete(int id)
        {
            var veiculo = _veiculos.FirstOrDefault(v => v.Id == id);
            if (veiculo == null) return NotFound();
            return View(veiculo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var veiculo = _veiculos.FirstOrDefault(v => v.Id == id);
            if (veiculo != null)
            {
                _veiculos.Remove(veiculo);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var veiculo = _veiculos.FirstOrDefault(v => v.Id == id);
            if (veiculo == null) return NotFound();
            return View(veiculo);
        }
    }
}