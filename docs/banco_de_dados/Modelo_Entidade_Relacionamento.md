
## ENTIDADES
**Fisioterapeuta** (idFisio, nomeFisio)

**Paciente** (idPaciente, cpfPaciente, nomePaciente, numeroSessoes, dataNascimento, {telefone})

**Movimento** (idMovimento, nomeMovimento, descricaoMovimento, pontosMovimento)

**Exercicio** (idExercicio, descricaoExercicio, pontosExercicio)

**Musculo** (idMusculo, nomeMusculo)

**Sessao** (idSessao, dataSessao, observacaoSessao)

**Pontos Rotulo Fisioterapeuta** (idRotuloFisioterapeuta, tempoInicial, tempoFinal, estagioMovimentoFisio)

**Pontos Rotulo Paciente** (idRotuloPaciente, tempoInicial, tempoFinal, estagioMovimentoPaciente)

## RELACIONAMENTOS
**fisioterapeuta** -- atende -- **paciente** <br />
_Um fisioterapeuta atende vários pacientes, assim como um paciente pode se consultar com vários
fisioterapeutas._ (cardinalidade n:m)  <br />

**movimento** -- estimula -- **musculo** <br />
_Um movimento estimula, obrigatoriamente, um ou mais músculos; e, um musculo, é estimulado por vários tipos de movimentos._ (cardinalidade n:m) <br />

**movimento** -- baseia -- **exercicio** <br />
_O exercicio, realizado pelo paciente, é baseado num movimento ideal._ (cardinalidade 1:n)  <br />

**fisioterapeuta** -- cadastra -- **movimento** <br />
_Um fisioterapeuta cadastra um ou vários movimentos._ (cardinalidade 1:n)  <br />

**paciente** -- realiza -- **exercicio** <br />
_Um paciente realiza um ou vários movimentos._ (cardinalidade 1:n)  <br />

**sessao** -- possui -- **exercicio** <br />
_Numa sessão, múltiplos exercícios são realizados._ (cardinalidade 1:n)

**paciente** -- participa -- **sessao** <br />
_Um paciente participa de uma ou várias sessões._ (cardinalidade 1:n)

**fisioterapeuta** -- conduz -- **sessao** <br />
_Um fisioterapeuta conduz uma ou variás sessões._ (cardinalidade 1:n)

**movimento** -- gera -- **pontos rotulo fisioterapeuta** <br />
_Um movimento gera n pontos nos eixos x e y._ (cardinalidade 1:n)

**exercicio** -- gera -- **pontos rotulo paciente** <br />
_Um exercicio gera n pontos nos eixos x e y._ (cardinalidade 1:n)