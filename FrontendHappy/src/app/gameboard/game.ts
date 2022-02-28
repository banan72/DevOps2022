
export class Game {

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



    for (let y = 0; y < dimension; y++) {
      for (let x = 0; x < dimension; x++) {
        const ctx = canvas.getContext('2d')!
        ctx.beginPath()
        ctx.fillStyle = 'rgba(169,169,169, 1)'
        ctx.rect((size + offset) * x, (size + offset) * y, size, size)
        ctx.fill()
      }
    }
  }

}
