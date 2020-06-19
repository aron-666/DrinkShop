Drinkshop.core 是一個簡易POS系統，由C#撰寫

Drinkshop_view 串接Line bot/Luis Ai/Pos系統，由Python撰寫

Luis設定檔：
LinOrders.json

資料庫使用mysql
將以下資料庫指令檔匯入資料庫：
drinkShop.sql

在 Drinkshop.core/appsettings.json可以編輯資料庫連接

設定檔：
Drinkshop.core/appsettings.json
Drinkshop_view/config/config.json
架起服務後需要編輯端點位置，否則無法使用。



line bot demo id:
@860nqnbp