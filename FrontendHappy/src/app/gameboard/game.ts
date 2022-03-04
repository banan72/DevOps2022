
export class Game {
  list: GameField[] = []
  bluePlayerPos: number = 0

  public Draw(): void {
    const dimension = 5
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
        this.list.push(gm)
        i++
      }
    }

    this.list[this.bluePlayerPos].setColor('rgb(0, 255, 255)')
  }

  moveOne(){
    this.list[this.bluePlayerPos].setColor('rgb(169,169,169, 1)')
    this.bluePlayerPos ++
    if(this.bluePlayerPos < this.list.length-1) {
      this.list[this.bluePlayerPos].setColor('rgb(0, 255, 255)')
    }
  }

}

class GameField{
  id:number
  x: number;
  y: number;
  size: number;
  offset: number;
  ctx: CanvasRenderingContext2D;


  constructor(id:number, x: number, y: number, size: number, ctx: CanvasRenderingContext2D, offset: number) {
    this.id = id
    this.x = x
    this.y = y
    this.size = size
    this.ctx = ctx;
    this.offset = offset
  }


  setColor(color:string){
    this.ctx.beginPath()
    this.ctx.fillStyle = color
    this.ctx.rect((this.size + this.offset) * this.x, (this.size + this.offset) * this.y, this.size, this.size)
    this.ctx.fill()
  }
}
