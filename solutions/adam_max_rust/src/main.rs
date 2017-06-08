#[derive(PartialEq, Debug)]
enum TTTResult {
    XWon,
    OWon,
    Draw,
    InProgress,
}
use TTTResult::*;


fn check_board_bytes(board: &[u8]) -> TTTResult {
    let windexes: Vec<[usize; 3]> = vec![[0, 1, 2], // First row
                                         [3, 4, 5], // Second row
                                         [6, 7, 8], // Third row
                                         [0, 3, 6], // First col
                                         [1, 4, 7], // Second col
                                         [2, 5, 8], // Second col
                                         [0, 4, 8], // Diagonal
                                         [2, 4, 6], // Diagonal other
                                        ];
    for idx in windexes.iter() {
        if idx.iter().map(|&i| board[i]).all(|c| c == 'X' as u8) {
            return XWon;
        }
        if idx.iter().map(|&i| board[i]).all(|c| c == 'O' as u8) {
            return OWon;
        }
    }
    if board.iter().any(|&c| c == ' ' as u8) {
        InProgress
    } else {
        Draw
    }
}

fn check_board(board: &str) -> TTTResult {
    check_board_bytes(board.as_bytes())
}

// fn check_board(board: &str) -> TTTResult {
//     let windexes: Vec<[usize; 3]> = vec![[0, 0, 0], // First row
//                                          [3, 0, 0], // Second row
//                                          [6, 0, 0], // Third row
//                                          [0, 2, 2], // First col
//                                          [1, 2, 2], // Second col
//                                          [2, 2, 2], // Second col
//                                          [0, 3, 3], // Diagonal
//                                          [2, 1, 1], // Diagonal other
//     ];
//     if windexes
//            .iter()
//            .any(|idxs| {
//                     let mut it = board.chars();
//                     let mut diag = idxs.iter().map(|i| it.nth(*i).unwrap());
//                     diag.all(|i| i == 'X')
//                 }) {
//         return XWon;
//     }
//     if windexes
//            .iter()
//            .any(|idxs| {
//                     let mut it = board.chars();
//                     let mut diag = idxs.iter().map(|i| it.nth(*i).unwrap());
//                     diag.all(|i| i == 'O')
//                 }) {
//         return OWon;
//     }
//     if board.chars().any(|c| c == ' ') {
//         InProgress
//     } else {
//         Draw
//     }
// }

#[cfg(test)]
mod foo {
    use super::*;

    #[test]
    fn test_returns_some_result() {
        assert_eq!(check_board("         "), InProgress);
    }

    #[test]
    fn test_empty_board() {
        assert_eq!(check_board("         "), InProgress);
    }

    #[test]
    fn test_x_won() {
        assert_eq!(check_board("XXXO O   "), XWon);
    }

    #[test]
    fn test_o_won() {
        assert_eq!(check_board("OOOO O   "), OWon);
    }

    #[test]
    fn test_x_won_on_diaganol() {
        assert_eq!(check_board("XOOOX   X"), XWon);
    }

    #[test]
    fn test_draw() {
        assert_eq!(check_board("XOXOXOOXO"), Draw);
    }

    #[test]
    fn test_x_won_second_row() {
        assert_eq!(check_board("OO XXX   "), XWon);
    }

    #[test]
    fn test_x_won_third() {
        assert_eq!(check_board("OO    XXX"), XWon);
    }
    #[test]
    fn test_o_won_firstcol() {
        assert_eq!(check_board("O XO  OXX"), OWon);
    }
    #[test]
    fn test_o_won_secondcol() {
        assert_eq!(check_board(" OX O XOX"), OWon);
    }
    #[test]
    fn test_o_won_thirdcol() {
        assert_eq!(check_board(" XO  OXXO"), OWon);
    }

    #[test]
    fn test_o_won_on_diaganol_other() {
        assert_eq!(check_board("XOOXOXO  "), OWon);
    }
}
