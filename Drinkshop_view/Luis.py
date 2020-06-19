import requests as request
import json
import urllib

class Luis:
    def __init__(self, url):
        self.url = url

    def Excute(self, str):
        try:
            exm = "無法辨識，請再試別的方式或檢查項目有沒有打錯\r\n範例：\r\n我要買一杯大杯可樂與四杯青茶少冰微糖0987987987\r\n-------------------\r\n大奶茶X2 半糖少冰\r\n大杯綠茶五杯微糖少冰還有大杯咖啡3杯台南人少冰\r\n再來三杯青茶胖胖杯無糖少冰\r\n綠茶x4半少\r\n0987987987"
            resp = request.get(self.url + "&" + urllib.parse.urlencode({'query': str}))

            j = json.loads(resp.text)

            buy = j['prediction']['entities'].get("Buying")
            phone = j['prediction']['entities'].get("Phone")
            if buy != None and phone != None:
                ret = {"ClientID": "", "Phone": phone[0], "Items": []}

                for i in buy:
                    temp = {}
                    if i.get('Item') != None:
                        temp["Name"] = i.get('Item')[0][0]
                    else:
                        return exm

                    if i.get('Size') != None:
                        temp["Size"] = i.get('Size')[0][0]

                    if i.get('Count') != None:
                        temp["Count"] = int(i.get('Count')[0][0].replace('杯', ''))

                    if i.get('Ice') != None:
                        temp["Ice"] = i.get('Ice')[0][0]

                    if i.get('Sweetness') != None:
                        temp["Sweetness"] = i.get('Sweetness')[0][0]
                    ret['Items'].append(temp)
                return ret
            else:
                if buy == None:
                    return exm
                elif phone == None:
                    return "請加入電話再試一次"
            
        except:

            return exm