"""
This script runs the Drinkshop_view application using a development server.
"""

from os import environ
from Drinkshop_view import app
from flask import Flask, request, abort
import json

from linebot import (
    LineBotApi, WebhookHandler
)
from linebot.exceptions import (
    InvalidSignatureError
)
from linebot.models import (
    MessageEvent, TextMessage, TextSendMessage, TemplateSendMessage, ButtonsTemplate, PostbackAction, MessageAction, URIAction, ConfirmTemplate, ImageSendMessage
)
from Luis import Luis as Luis

from Pos import Pos as Pos
cache = []
with open('config/config.json') as json_file:
    str1 = json_file.read()
    config = json.loads(str1)
line_bot_api = LineBotApi(config['Linebot'].get('token'))
handler = WebhookHandler(config['Linebot'].get('channel_secret'))

luis = Luis(config['LuisUrl'])

pos = Pos(config['Pos'])

@app.route("/api/paysuccess", methods=['POST'])
def paysuccess():
    body = json.loads(request.get_data(as_text=True))
    
    line_bot_api.push_message(body['id'], TextSendMessage(text=body['text']))



@app.route("/api/linebot", methods=['POST'])
def linebot():
    # get X-Line-Signature header value
    signature = request.headers['X-Line-Signature']

    # get request body as text
    body = json.loads(request.get_data(as_text=True))



    if body['events'][0]['type'] == 'postback':
        back = body['events'][0]['postback']['data']
        index = int(back)
        back = cache[index]
        posResp = pos.CreateOrder(json.loads(back))
        strx = f"訂單已成立\r\n總金額為：{posResp['data']['Price']}\r\n付款網址：{posResp['data']['PayUrl']}\r\n瀏覽訂單：{posResp['data']['OrderUrl']}"
        handle_message(body['events'][0], strx)
    else:
        text = body["events"][0].get("message").get("text")

        if(text == '菜單' or text.upper() == 'MENU'):
            #回傳菜單
            "/images/menu.png"
            ""
            send_image(body['events'][0], pos.GetMenuUrl())
        elif text == '取消':
            handle_message(body['events'][0], '已取消')
        else:
            luisResp = luis.Excute(text)
            if(type(luisResp) == str):
                handle_message(body['events'][0], luisResp)
            
            else:
                luisResp["ClientID"] = body["events"][0]["source"]["userId"]
                #print(luisResp)
                posResp = pos.GetPrice(luisResp["Items"])
                tt = OrderText(posResp)
                button_msg(body['events'][0], tt, json.dumps(luisResp, ensure_ascii = False))
    return 'OK'

def OrderText(order):
    strx = '您的訂單為下，確認無誤按<確認>。\r\n'
    for i in order['data']['Items']:
        strx = strx + f"{i['Name']}, X{i['Count']}, {i['Sweetness']}, {i['Ice']}, {i['Size']}   ${i['Price']}\r\n"
    strx =  strx + '------------------\r\n'
    strx = strx + "總金額:$" + str(order['data']['Total'])
    return strx


@handler.add(MessageEvent, message=TextMessage)
def handle_message(event, text):
    line_bot_api.reply_message(
        event["replyToken"],
        TextSendMessage(text=text))
def send_image(event, url):
    image_message = ImageSendMessage(
        original_content_url=url,
        preview_image_url=url
    )
    line_bot_api.reply_message(
        event["replyToken"],
        image_message
    )

def button_msg(event, title, order):
    cache.append(order)
    index = len(cache) - 1
    confirm_template_message = TemplateSendMessage(
    alt_text='Confirm template',
    template=ConfirmTemplate(
        text=title,
        actions=[
            PostbackAction(
                label='確認',
                display_text='確認',
                data=str(index)
            ),
            MessageAction(
                label='取消',
                text='取消'
            )
        ]
    )
    )
    line_bot_api.reply_message(
        event["replyToken"],
        confirm_template_message)

if __name__ == '__main__':
    HOST = environ.get('SERVER_HOST', '0.0.0.0')
    try:
        PORT = int(environ.get('SERVER_PORT', '5555'))
    except ValueError:
        PORT = config.get('Port')
    PORT = config.get('Port')
    #app.debug = True
    app.run(HOST, PORT)#, ssl_context=('D:\\Downloads\\certificate.crt', 'D:\\Downloads\\private.key'))


