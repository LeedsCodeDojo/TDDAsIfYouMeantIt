package co.jfactory

typealias Board = List<List<Int>>

fun Board.status(): String {
    val winners = Player.values().filter { player -> hasPlayerWon(player)}
    return when {
        winners.size > 1 || hasUnbalancedMoves() -> "Invalid Board"
        winners.size == 1 -> "Winner: ${winners[0].id}"
        isFull() -> "Draw"
        else -> "In Progress"
    }
}

private fun Board.isFull() = !this.flatMap { it.filter { it == 0 } }.any()

private fun Board.hasUnbalancedMoves() : Boolean {
    return Math.abs(movesMade(Player.Player1) - movesMade(Player.Player2)) > 1
}

private fun Board.movesMade(player: Player) = this.flatMap { it.filter { it == player.id } }.count()

private fun Board.hasPlayerWon(player: Player): Boolean {
    return (this.any { it.all { it == player.id } } // Horizontal Lines
            || IntRange(0, 2).any { col -> this.all { it[col] == player.id } } // Vertical Lines
            || IntRange(0, 2).all { this[it][it] == player.id } // Forward Diagonal
            || IntRange(0, 2).all { this[it][2 - it] == player.id } // Backward Diagonal
            )
}

enum class Player(val id: Int) { Player1(1), Player2(2) }
