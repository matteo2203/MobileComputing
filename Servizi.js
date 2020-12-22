const express=require('express');
var mysql = require('mysql');
var app = express();

const dbhostname='db4free.net';
const dbport=3306;

var con = mysql.createConnection({
  host: dbhostname,
  user: 'aressgia',
  password: 'Forzaitalia0',
  database: 'mobilecomputing'
});

app.listen(process.env.PORT || 3000, ()=>{
  con.connect(function(err) {
    if (err) throw err;
    console.log("Connected!");
  });
  console.log('cacca');
});

app.get("/livelli", (req, res, next) => {
  con.query("SELECT * FROM livelli", (err, result) => {
    if(err) throw err;
    console.log(result);
    var stringResult = [];
    var count = 0;
    for(r in result) {
      stringResult[count] = r;
      count++;
    }
    res.end(r);
  })
});

app.get("/creaUser", (req, res, next) => {
  var nome = req.query.nome;
  var password = req.query.password;
  let queryData = [nome, password];

  con.query("INSERT INTO utenti (nome, psw) VALUES (?, ?)", queryData, (err) => {
    if(err) throw err;
    con.query("SELECT * FROM utenti WHERE nome = ?", [nome], (err, result) => {
      if(err) throw err;
      res.status(200).send(result);
    })
  });
});

app.get("/getUser", (req, res, next) => {
  var nome = req.query.nome;
  var password = req.query.password;

  con.query("SELECT * FROM utenti WHERE nome = ? AND psw = ?", [nome, password], (err, result) => {
    if(err) throw err;
    if(result.length > 0) {
      res.status(200).send(result);
    } else {
      res.status(400).send('{"message": "Utente non trovato"}');
    }
  });
});
