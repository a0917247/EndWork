# EndWork
1. 首頁跟singlejob 頁面都成功進MVC裡 , 剩下部分麻煩照著範例進行
2. layout navbar 部分請改成 MVC 版本 , 不然不會運作 , li 裡的 class 請自行調整 , 範例在第 68 行
3. HomeController 要加
public IActionResult jobSingle()
        {
            return View();
        }
不然controller會無法產生相應的頁面 , layout 的 asp-action 請跟 controller一樣
不然後面容易產生問題
最後 有問題都歡迎找我討論 jing 留