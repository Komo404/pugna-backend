
Bom, é uma API de um jogo web
Usa o Render que é um PaaS, então o limite vai ser provavelmente memória e CPU e muito talvez banda larga mas acho que tudo isso é contornável, afinal o jogo em sí é uma demo de cubos e etc só pra demonstrar o threeJS e o servidor

Possíveis feats:

- Um sistema de sign up e login pra salvar infos do player
- Um sistema de estatísticas (tempo, partidas jogadas, vitórias/derrotas, etc. Justificaria um perfil)
- Um sistema de leaderboard (justificaria um backend)

- Sistema de rooms (CRUD de Rooms, provavelmente um websocket para sincronização?)
Inclui ciclo de vida da sala e proteção de dados/autorização. Talvez reconexão

- Sistema de partida e sincronização entre os players com o backend verificando as atividades, talvez?
Inclui ciclo de vida da partida ()

- Talvez um sistema anti trapaça?