"""
검은색 : 1, 흰색 : 2
가로, 세로, 대각선으로 5개가 연속되면 승리 (6개는 승리가 아님!!)
대각선은 우상향, 우하향만 고려
승리한 색과 좌표 출력
승리한 색이 없으면 0 출력
"""

import sys
sys.setrecursionlimit(10**6)
input = sys.stdin.readline 
board = [list(map(int,input().split())) for _ in range(19)]
ways = [(1,0),(0,1),(1,1),(-1,1)]

def dfs(x,y,color):
    for wx,wy in ways: 
        nx, ny = x + wx, y + wy
        cnt = 1

        while 0 <= nx < 19 and 0 <= ny < 19 and board[nx][ny] == color:
            cnt += 1

            if cnt == 5:
                # 6개는 승리가 아님
                if 0 <= x - wx < 19 and 0 <= y - wy < 19 and board[x - wx][y - wy] == color:
                    break
                if 0 <= nx + wx < 19 and 0 <= ny + wy < 19 and board[nx + wx][ny + wy] == color:
                    break
                return True
            
            # 같은 방향으로 dfs 이동
            nx += wx
            ny += wy
                
    return False

for i in range(19):
    for j in range(19):
        if board[i][j] == 0:
            continue

        if dfs(i,j,board[i][j]):
            print(board[i][j])
            print(i+1,j+1)
            sys.exit(0)

print(0)