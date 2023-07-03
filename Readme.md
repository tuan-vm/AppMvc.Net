##Controller
- La mot lop ke thua tu lop Controller : Microsoft.ASpNetCore.MVC.Controller
- action trong controller la mot phuong thuc public (khong duoc static)
_Action trar ve bat ki kieu du lieu nao , thuong la IActionResult
- Cac dich vu inject vaof controller qua ham tao

##View 
-La file .cshtml
- View cho Action luu tai : /View/ControllerName/ActionName.cshtml
- Them thu muc luu tru View tai Startup

##Truyen du lieu sang View
-Model
_ViewData
-ViewBag
-TempData

## Areas
- La ten nguoi dung routing
- La cau truc thu muc chua MVC
- Thiet lap Area cho controller bang  [Area("AreaName")]
- Tao cau truc thu muc

dotnet aspnet-codegenerator area Product
