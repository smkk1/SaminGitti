from bluetooth import *
from sense_hat import SenseHat
import threading
from evdev import InputDevice, categorize, ecodes
import sys
import time

sammutaRatti = False
gyro_akselit = "0.0,0.0,0.0"
nappikoodi = "0" # event.code
nappi_arvo = "0" # event.value
kaikki = "0"
#napit =""

napit = ["297", "0", "298", "0"]

kaasu = napit[0]
kaasuArvo = napit[1]
pakki = napit[2]
pakkiArvo = napit[3]


#def create_connection():
if sys.version < '3':
    nput = raw_input
#addr = "C8:21:58:73:64:68"
#addr ="C8:21:58:73:5e:f5"
addr = "88:78:73:49:46:47"
        
if len(sys.argv) < 2:
    print("no device specified.  Searching all nearby bluetooth devices for")
    print("the SampleServer service")
else:
    addr = sys.argv[1]
    print("Searching for SampleServer on %s" % addr)

# search for the SampleServer service
uuid = "94f39d29-7d6d-437d-973b-fba39e49d4ee"
service_matches = find_service( uuid = uuid, address = addr )

if len(service_matches) == 0:
    print("couldn't find the SampleServer service =(")
    sys.exit(0)


first_match = service_matches[0]
port = first_match["port"]
name = first_match["name"]
host = first_match["host"]

print("connecting to \"%s\" on %s" % (name, host))

# Bluetooth client socket
sock=BluetoothSocket( RFCOMM )
sock.connect((host, port))

sense = SenseHat()
sense.clear()

# Threadi
def gyro_data():
   
   
    global gyro_akselit
    
    while True:
        o = sense.get_orientation_degrees()
        pitch = o["pitch"]
        roll = o["roll"]
        yaw = o["yaw"]
        
        data = str(round(pitch,2))+","+str(round(roll,2))+","+str(round(yaw,2))
        #print(data)
        
        gyro_akselit = data



# Threadi
def button_input():
   
   #time.sleep(0.1)
   gamepad = InputDevice('/dev/input/event6')
   
   global nappikoodi
   global nappi_arvo
   global napit
   
   global kaasu
   global kaasuArvo
   global pakki
   global pakkiArvo
   
   for event in gamepad.read_loop():
    #Boutons | buttons
       if event.type == ecodes.EV_KEY:
           value = str(event.value)
           nappikoodi = str(event.code)
           nappi_arvo = value
           
           if nappikoodi == "297":
               napit[1] = nappi_arvo
               #print(napit)
               
               
           if nappikoodi == "298":
               napit[3] = nappi_arvo
               #print(napit)
               
           
           #napit = [kaasu, kaasuArvo, pakki, pakkiArvo]
           #napit = napit + "," + nappikoodi + "," + nappi_arvo
          #napit += "," + nappikoodi + "," + nappi_arvo
    #print(napit)
    

def send_data():
    
    global napit
    
    while True:
        #time.sleep(0.5)
        kaikki = str(gyro_akselit)+","+",".join(napit)
        #+str(nappikoodi)+","+str(nappi_arvo)
        #kaikki = str(gyro_akselit)+","+str(nappikoodi)+","+str(nappi_arvo)
        #print(kaikki)
        print(kaikki)
        sock.send(kaikki)



# Aloitetaan threadit
try:
    threading.Thread(target=gyro_data).start()
    threading.Thread(target=button_input).start()
    threading.Thread(target=send_data).start()
except:
    print("Virhe: Threadia ei pystytty kaynnistamaan")
    sock.close() # Bluetooth socketin sulkeminen
    

#while True:
    #if sammutaRatti == True:
    #   sys.exit(0)
    #else:
    #   pass
#   pass

#sock.close() # Bluetooth socketin sulkeminen

#string[] foos = clientMessage.Split(",")

