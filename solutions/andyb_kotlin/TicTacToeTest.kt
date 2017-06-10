package co.jfactory

import org.hamcrest.MatcherAssert.assertThat
import org.hamcrest.core.IsEqual.equalTo
import org.junit.Test

class TicTacToeTest {

    @Test fun `Given empty board then should return in progress`() {
        val board = listOf(listOf(0, 0, 0), listOf(0, 0, 0), listOf(0, 0, 0))
        assertThat(board.status(), equalTo("In Progress"))
    }

    @Test fun `Given board with 1st Row of complete horizontal line of ones then should return Winner 1`() {
        val board = listOf(listOf(1, 1, 1), listOf(0, 2, 0), listOf(0, 2, 0))
        assertThat(board.status(), equalTo("Winner: 1"))
    }

    @Test fun `Given board with 2nd Row of complete horizontal line of ones then should return Winner 1`() {
        val board = listOf(listOf(0, 2, 0), listOf(1, 1, 1), listOf(0, 2, 0))
        assertThat(board.status(), equalTo("Winner: 1"))
    }

    @Test fun `Given board with 3rd row of complete horizontal line of ones then should return Winner 1`() {
        val board = listOf(listOf(0, 2, 0), listOf(0, 2, 0), listOf(1, 1, 1))
        assertThat(board.status(), equalTo("Winner: 1"))
    }

    @Test fun `Given board with 1st Row of complete horizontal line of twos then should return Winner 2`() {
        val board = listOf(listOf(2, 2, 2), listOf(0, 1, 0), listOf(0, 1, 0))
        assertThat(board.status(), equalTo("Winner: 2"))
    }

    @Test fun `Given board with 2nd Row of complete horizontal line of twos then should return Winner 2`() {
        val board = listOf(listOf(0, 1, 0), listOf(2, 2, 2), listOf(1, 1, 0))
        assertThat(board.status(), equalTo("Winner: 2"))
    }

    @Test fun `Given board with 3rd row of complete horizontal line of twos then should return Winner 2`() {
        val board = listOf(listOf(1, 0, 1), listOf(1, 0, 0), listOf(2, 2, 2))
        assertThat(board.status(), equalTo("Winner: 2"))
    }

    @Test fun `Given a board where both players have won then should return Invalid Board`() {
        val board = listOf(listOf(1, 1, 1), listOf(0, 0, 0), listOf(2, 2, 2))
        assertThat(board.status(), equalTo("Invalid Board"))
    }

    @Test fun `Given board with 1st column of complete vertical line of ones then should return Winner 1`() {
        val board = listOf(listOf(1, 2, 1), listOf(1, 0, 0), listOf(1, 2, 2))
        assertThat(board.status(), equalTo("Winner: 1"))
    }

    @Test fun `Given board with 2nd column of complete vertical line of ones then should return Winner 1`() {
        val board = listOf(listOf(2, 1, 1), listOf(0, 1, 0), listOf(2, 1, 2))
        assertThat(board.status(), equalTo("Winner: 1"))
    }

    @Test fun `Given board with 3rd column of complete vertical line of ones then should return Winner 1`() {
        val board = listOf(listOf(2, 2, 1), listOf(0, 0, 1), listOf(2, 1, 1))
        assertThat(board.status(), equalTo("Winner: 1"))
    }

    @Test fun `Given board with 3rd column of complete vertical line of twos then should return Winner 2`() {
        val board = listOf(listOf(1, 0, 2), listOf(0, 1, 2), listOf(2, 1, 2))
        assertThat(board.status(), equalTo("Winner: 2"))
    }

    @Test fun `Given board with forward diagonal line of ones then should return Winner 1`() {
        val board = listOf(listOf(1, 0, 1), listOf(2, 1, 0), listOf(2, 2, 1))
        assertThat(board.status(), equalTo("Winner: 1"))
    }

    @Test fun `Given board with backward diagonal line of ones then should return Winner 1`() {
        val board = listOf(listOf(2, 0, 1), listOf(2, 1, 0), listOf(1, 2, 1))
        assertThat(board.status(), equalTo("Winner: 1"))
    }

    @Test fun `Given a full board with no complete lines then should return Draw`() {
        val board = listOf(listOf(2, 1, 2), listOf(2, 1, 2), listOf(1, 2, 1))
        assertThat(board.status(), equalTo("Draw"))
    }

    @Test fun `Given a board with too many moves by Player 1 then should return Invalid Board`() {
        val board = listOf(listOf(2, 1, 1), listOf(0, 1, 0), listOf(0,0,0))
        assertThat(board.status(), equalTo("Invalid Board"))
    }

}
