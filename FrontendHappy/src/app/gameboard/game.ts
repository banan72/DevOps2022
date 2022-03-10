
export class Game {
  gameFields: GameField[] = []
  activeGamepieces: GamePiece[] = []
  gamePieceColors: string[] = ['rgb(0, 255, 255)', 'rgb(255,0,0)', 'rgb(69, 75, 27)', 'rgb(247, 222, 58)']
  maxPlayers:number = 4

  activePlayer: GamePiece = this.activeGamepieces[0]
  turn: number = 0


  public Draw(): void {
    const dimension = 6
    const size = 100
    const offset = 10
    // Create and attach Canvas to the DOM
    const canvas = document.createElement('canvas')
    const canvasSize = (size + offset) * dimension + offset
    canvas.setAttribute('width', canvasSize.toString())
    canvas.setAttribute('height', canvasSize.toString())
    document.body.appendChild(canvas)


    let i = 0
    for (let y = 0; y < dimension; y++) {
      for (let x = 0; x < dimension; x++) {
        const ctx = canvas.getContext('2d')!
        let gm = new GameField(i, x, y, size, ctx, offset)
        gm.setColor('rgba(169,169,169, 1)')
        this.gameFields.push(gm)
        i++
      }
    }
  }

  setPlayers(total:number){
    if(total<=this.maxPlayers){
      for(let i = 0; i<total; i++){
        let gp = new GamePiece(i, this.gamePieceColors[i])
        this.activeGamepieces.push(gp)
        this.gameFields[gp.pos].addNewGamePiece(gp)
      }

      this.activePlayer =this.activeGamepieces[this.turn]
    }
    else{
      //TODO error
    }
  }


  move(places: number){
    this.gameFields[this.activePlayer.pos].removeGamePiece(this.activePlayer.id)
    this.gameFields[this.activePlayer.pos].setColor('rgb(169,169,169, 1)')
    this.activePlayer.pos += places as number
    if(this.activePlayer.pos < this.gameFields.length-1) {
      this.gameFields[this.activePlayer.pos].addNewGamePiece(this.activePlayer)
    }
    else {
      this.activePlayer.pos  =this.gameFields.length-1
      this.gameFields[this.activePlayer.pos ].addNewGamePiece(this.activePlayer)
      this.removeGamePiece(this.activePlayer.id)
    }
  }

  removeGamePiece(gpId: number){
    let d = -1
    for(let i = 0; i<this.activeGamepieces.length; i++){
      if(this.activeGamepieces[i].id == gpId){
        d = i
      }
    }

    if(d!= -1){
      this.activeGamepieces.splice(d, 1)
    }
  }

  nextPlayer(){
    if(this.activeGamepieces.length > 0) {
      if (this.turn + 1 >= this.activeGamepieces.length) {
        this.turn = 0
      } else {
        this.turn++
      }

      this.activePlayer = this.activeGamepieces[this.turn]
    }

    return this.activePlayer.id
  }

  roll(): number {
    let dieRoll  = Math.floor(Math.random() * (6 - 1 + 1)) + 1
    return dieRoll
  }
}

class GameField{
  gamePieceColors: string[] = ['rgb(0, 255, 255)', 'rgb(255,0,0)', 'rgb(69, 75, 27)', 'rgb(247, 222, 58)']
  id:number
  x: number;
  y: number;
  size: number;
  offset: number;
  ctx: CanvasRenderingContext2D;
  gamePiecesOnField: GamePiece[]  =[]


  constructor(id:number, x: number, y: number, size: number, ctx: CanvasRenderingContext2D, offset: number) {
    this.id = id
    this.x = x
    this.y = y
    this.size = size
    this.ctx = ctx;
    this.offset = offset
  }

  addNewGamePiece(gp: GamePiece){
    this.gamePiecesOnField.push(gp)
    this.setGamePieces()
  }

  removeGamePiece(gpId: number){
    let d = -1
    for(let i = 0; i<this.gamePiecesOnField.length; i++){
      if(this.gamePiecesOnField[i].id == gpId){
        d = i
      }
    }

    if(d!= -1){
      this.gamePiecesOnField.splice(d, 1)
    }
  }

  setGamePieces(){
    if(this.gamePiecesOnField.length>0) {
      for (let i = 0; i < this.gamePiecesOnField.length; i++) {
        let gp = this.gamePiecesOnField[i]
        let gpSize = this.size / 2
        this.ctx.beginPath()
        this.ctx.fillStyle = gp.color
        if (gp.id == 0) {
          this.ctx.rect((this.size + this.offset) * this.x, (this.size + this.offset) * this.y, gpSize, gpSize)
        } else if (gp.id == 1) {
          this.ctx.rect((this.size + this.offset) * this.x + gpSize, (this.size + this.offset) * this.y, gpSize, gpSize)
        } else if (gp.id == 2) {
          this.ctx.rect((this.size + this.offset) * this.x, (this.size + this.offset) * this.y + gpSize, gpSize, gpSize)
        } else if (gp.id == 3) {
          this.ctx.rect((this.size + this.offset) * this.x + gpSize, (this.size + this.offset) * this.y + gpSize, gpSize, gpSize)
        }
        this.ctx.fill()
      }
    }

  }


  setColor(color:string){
    this.ctx.beginPath()
    this.ctx.fillStyle = color
    this.ctx.rect((this.size + this.offset) * this.x, (this.size + this.offset) * this.y, this.size, this.size)
    this.ctx.fill()

    this.setGamePieces()
  }
}

class GamePiece{
  id:number
  pos:number =  0
  color: string

  constructor(id: number, color:string) {
    this.id = id;
    this.color = color;
  }
}
