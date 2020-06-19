import json
import requests as request

class Pos:
    def __init__(self, pos):
        self.pos = pos

    def GetPrice(self, data):
        data = json.dumps(data, ensure_ascii=False).encode()
        headers ={'Content-Type': 'application/json'}
        resp = request.post(self.pos["Endpoint"] + self.pos["api"]["GetPrice"], data = data, headers = headers)
        j = json.loads(resp.text)
        return j

    def CreateOrder(self, data):
        data = json.dumps(data, ensure_ascii=False).encode()
        headers ={'Content-Type': 'application/json'}
        resp = request.post(self.pos["Endpoint"] + self.pos["api"]["CreateOrder"], data = data, headers = headers)
        j = json.loads(resp.text)
        return j
    def GetMenuUrl(self):
        return self.pos["Endpoint"] + "/images/menu.png"