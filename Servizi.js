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
      res.status(200).send(result[0]);
    } else {
      res.status(400).send('{"message": "Utente non trovato"}');
    }
  });
});

app.get("/getUserStatForLevel", (req, res, next) => {
  var idUtente = req.query.utente;

  con.query("SELECT * FROM punteggi WHERE id_utente = ?", [idUtente], (err, result) => {
    if(err) throw err;
    res.status(200).send({scores: result});
  });
});

app.get("/saveUserStatForLevel", (req, res, next) => {
  var idUtente = req.query.utente;
  var livello = req.query.livello;
  var score = req.query.score;
  toUpdate = false;
  con.query("SELECT score FROM punteggi WHERE id_utente = ? AND id_livello = ?", [idUtente, livello], (err, result) => {
    if(err) throw err;
    if(result.score < score) toUpdate = true;
  });

  if(!toUpdate) {
    con.query("INSERT INTO punteggi VALUES (?, ?, ?)", [livello, idUtente, score], (err, result) => {
      if(err) throw err;
      res.status(200).send({status: "ok"});
    });
  } else {
    con.query("UPDATE punteggi SET score = ? WHERE id_utente = ? AND id_livello = ?", [score, idUtente, livello], (err, result) => {
      if(err) throw err;
      res.status(200).send({status: "ok"});
    });
  }
});

app.get("/getRankForLevels", (req, res, next) => {
  var scores = {};

  con.query("SELECT nome, score FROM punteggi JOIN utenti ON id_utente = id AND id_livello = 1 ORDER BY score DESC LIMIT 10", (err, result) => {
    if(err) throw err;
    scores.lvl1 = result;
  });
  con.query("SELECT nome, score FROM punteggi JOIN utenti ON id_utente = id AND id_livello = 2 ORDER BY score DESC LIMIT 10", (err, result) => {
    if(err) throw err;
    scores.lvl2 = result;
  });
  con.query("SELECT nome, score FROM punteggi JOIN utenti ON id_utente = id AND id_livello = 3 ORDER BY score DESC LIMIT 10", (err, result) => {
    if(err) throw err;
    scores.lvl3 = result;
    res.status(200).send(scores);
  });
});

app.get("/getGlobalScores", (req, res, next) => {
  con.query("SELECT nome, scoreTotale as score FROM SommaLivelliPerUtente ORDER BY scoreTotale DESC LIMIT 10", (err, result) => {
    if(err) throw err;
    console.log(result);
    res.status(200).send({
      scores: result
    });
  });
});