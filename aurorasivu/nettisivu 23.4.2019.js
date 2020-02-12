const express = require('express')
const app = express()
const port = 3000
var bodyParser=require('body-parser')
var http = require ('http');
var url= require ('url');
var MongoClient= require('mongodb').MongoClient;
var mongoURL= 'mongodb://127.0.0.1/27017';





// TÃ¤tÃ¤ tarvitaan, jos post-metodilla lÃ¤hetetÃ¤Ã¤n parametreja. 
// Ei siis tÃ¤ssÃ¤ esimerkissÃ¤ tarpeellinen, mutta ei haittaakaan



app.use(bodyParser.urlencoded({extended:true}))
app.use(express.static('images'));

// Tarvitaan, ettÃ¤ voidaan lÃ¤hettÃ¤Ã¤ api request tiettyyn osoitteeseen. 
var request = require('request');

// Kun otetaan yhteys porttiin ilman polkua (Esim. localhost:3000
app.get('/', (req, res) => res.sendFile(__dirname + '/new.html'))
app.get('/alldata', (req, res) => res.sendFile(__dirname + '/alldata.html'))
app.get('/muutakk', (req, res) => res.sendFile(__dirname + '/muutakk.html'))



// Kun otetaan yhteyttÃ¤ osoitteeseen localhost:3000/readData
// Luetaan sodankylän dataa 24h ajalta 
app.get('/readData', function (req, res) { 
	console.log("Reading data");

	request({ uri: 'http://space.fmi.fi/image/realtime/FIN/SOD/SODdata_24.txt' }, function (error, response, body) {  
		if (error && response.statusCode !== 200) {
			console.log('Error when contacting the internet address')
		}
		var dataArray = [];
		
		// Splitataan data. ErotinmerkkinÃ¤ rivinvaihto
		var str = body.split("\n");
		var i;
		// KÃ¤ydÃ¤Ã¤n data alkio alkiolta lÃ¤pi. HypÃ¤tÃ¤Ã¤n kaksi ensimmÃ¤istÃ¤ alkiota yli, koska ovat vain otsikkotietoa
		// Varsinainen data alkaa kolmannelta riviltÃ¤ eli 2. alkiosta
		for (i=2;i<(str.length-1); i++)
		{
			// RivillÃ¤ 4 tyhjÃ¤Ã¤ vÃ¤lilyÃ¶ntiÃ¤ erottaa alkuosan rivistÃ¤ ja loppuosan
			var dataLine = str[i].split("    ");
			//console.log("alkuosa = " + dataLine[0]);
			//console.log("loppuosa = " + dataLine[1]);
			
			// Loppuosa splitataan. VÃ¤lilyÃ¶nti erotinmerkkinÃ¤. 
			var auroraData = dataLine[1].split(" ");
			
			console.log("SOD X = " + auroraData[0]);
			console.log("SOD Y = " + auroraData[2]);
			console.log("SOD Z = " + auroraData[3]);
			
			// TEhdÃ¤Ã¤n objekti, johon tallennetaan tÃ¤rkeÃ¤ data kyseiseltÃ¤ riviltÃ¤. 
			var data = { x: auroraData[0], y: auroraData[2], z: auroraData[3]};
			
			var oikea_data_x = Math.pow(data.x,2);
			var oikea_data_y = Math.pow(data.y,2);
			var oikea_data_z = Math.pow(data.z,2);
			
			var plussa = oikea_data_x+oikea_data_y+oikea_data_z;
			var viimeinen = Math.sqrt(plussa);
		
			
			// LisÃ¤tÃ¤Ã¤n data array:hin
			//dataArray.push(data);
			dataArray.push(viimeinen);
		}
		// LÃ¤hetetÃ¤Ã¤n array (eli javascript objekti) vastauksena. 
		res.send(dataArray);
		//res.send(viimeinen);
		
	});
	
});


app.get('/kaikkidata', function (req, res) { 
MongoClient.connect (mongoURL, function (err,db) {
if(err){
	 throw err;
 }
var dbo=db.db("myDB");
dbo.collection("senseData").find().sort({Aika:-1}).limit(12).toArray(function(err,results){
	 
	if (err) throw err;
	console.log(results);
	
	db.close();
	var myResult=JSON.stringify(results);
	console.log(myResult);
	res.write(myResult);
	res.end();
});
});
});



// SENSEDATA JUTSKAT
app.get('/sense', function (req, res) { 
MongoClient.connect (mongoURL, function (err,db) {
if(err){
	 throw err;
 }
var dbo=db.db("myDB");
dbo.collection("senseData").find().sort({Aika:-1}).limit(2).toArray(function(err,results){
	 
	if (err) throw err;
	console.log(results);
	
	db.close();
	var myResult=JSON.stringify(results);
	console.log(myResult);
	res.write(myResult);
	res.end();
});
});
});
app.get('/images', function (req, res) { 
});

app.get('/SodData', function (req, res) { 
	console.log("Reading data");

	request({ uri: 'http://space.fmi.fi/image/realtime/FIN/SOD/SODdata_24.txt' }, function (error, response, body) {  
		if (error && response.statusCode !== 200) {
			console.log('Error when contacting the internet address')
		}
		var dataArray = [];
		
		// Splitataan data. ErotinmerkkinÃ¤ rivinvaihto
		var str = body.split("\n");
		var i;
		// KÃ¤ydÃ¤Ã¤n data alkio alkiolta lÃ¤pi. HypÃ¤tÃ¤Ã¤n kaksi ensimmÃ¤istÃ¤ alkiota yli, koska ovat vain otsikkotietoa
		// Varsinainen data alkaa kolmannelta riviltÃ¤ eli 2. alkiosta
		for (i=2;i<(str.length-1); i++)
		{
			// RivillÃ¤ 4 tyhjÃ¤Ã¤ vÃ¤lilyÃ¶ntiÃ¤ erottaa alkuosan rivistÃ¤ ja loppuosan
			var dataLine = str[i].split("    ");
			//console.log("alkuosa = " + dataLine[0]);
			//console.log("loppuosa = " + dataLine[1]);
			
			// Loppuosa splitataan. VÃ¤lilyÃ¶nti erotinmerkkinÃ¤. 
			var auroraData = dataLine[1].split(" ");
			
			console.log("SOD X = " + auroraData[0]);
			console.log("SOD Y = " + auroraData[2]);
			console.log("SOD Z = " + auroraData[3]);
			
			// TEhdÃ¤Ã¤n objekti, johon tallennetaan tÃ¤rkeÃ¤ data kyseiseltÃ¤ riviltÃ¤. 
			var data = { x: auroraData[0], y: auroraData[2], z: auroraData[3]};
			
			var oikea_data_x = Math.pow(data.x,2);
			var oikea_data_y = Math.pow(data.y,2);
			var oikea_data_z = Math.pow(data.z,2);
			
			var plussa = oikea_data_x+oikea_data_y+oikea_data_z;
			var viimeinen = Math.sqrt(plussa);
		
			
			// LisÃ¤tÃ¤Ã¤n data array:hin
			dataArray.push(data);
			//dataArray.push(viimeinen);
		}
		// LÃ¤hetetÃ¤Ã¤n array (eli javascript objekti) vastauksena. 
		res.send(dataArray);
		//res.send(viimeinen);
		
	});
	
});



app.listen(8080, function() { 
	console.log("Listening port 8080")
});