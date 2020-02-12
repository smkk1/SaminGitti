from bluetooth import *
from pynput.keyboard import Key, Controller
import socket

hostname, sld, tld, port = 'www', 'integralist', 'co.uk', 80
target = '{}.{}.{}'.format(hostname, sld, tld)

# create an ipv4 (AF_INET) socket object using the tcp protocol (SOCK_STREAM)
client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

# connect the client
# client.connect((target, port))
client.connect(('127.0.0.1', 8052))

# send some data (in this case a HTTP GET request)


# receive the response data (4096 is recommended buffer size)













keyboard = Controller()


server_sock=BluetoothSocket( RFCOMM )
server_sock.bind(("",PORT_ANY))
server_sock.listen(1)

port = server_sock.getsockname()[1]

uuid = "94f39d29-7d6d-437d-973b-fba39e49d4ee"

advertise_service( server_sock, "SampleServer",
                   service_id = uuid,
                   service_classes = [ uuid, SERIAL_PORT_CLASS ],
                   profiles = [ SERIAL_PORT_PROFILE ], 
#                   protocols = [ OBEX_UUID ] 
                    )
                   
print("Waiting for connection on RFCOMM channel %d" % port)

client_sock, client_info = server_sock.accept()
print("Accepted connection from ", client_info)

#try:
while True:
    data = client_sock.recv(2048)
    if len(data) == 0: break
                #print("received [%s]" % data)
    #stringData = str(data)
    #stringDataSplit = stringData.split(",")
    #print(stringData)
    #print(stringDataSplit[1], stringDataSplit[2], stringDataSplit[3][0:-1])
    print(data)
    client.send(data)
    
                #print(data[0])
                #keyboard.press(chr(data[0]))
                #keyboard.release(chr(data[0]))
#except IOError:
    #pass

print("disconnected")

client_sock.close()
server_sock.close()
print("all done")




