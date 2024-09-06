// 주 대각선, 중간 열, 부 대각선, 중간 행을 제외한 원소의 위치는 달라지지 않는다.

let t = Int(readLine()!)! // 테스트 케이스의 수

for _ in 0..<t { // O(10)
    let numbers = readLine()!.split(separator: " ").map { Int($0)! }
    var (n, d) = (numbers[0], numbers[1]/45) // 배열의 크기 n, 각도 d
    
    // 배열 만들기
    var arr = Array(repeating: Array(repeating: 0, count: n), count: n)
    for i in 0..<n { // O(10*500)
        for j in 0..<n { // O(10*500*500) 250만
            arr[i][j] = n*i + (j+1)
        }
    }
    
    // 반시계방향(음수)이라면 그에 대응되는 시계방향으로 변환
    if d < 0 {
        d += 8
    }
    
    var temp = Array(repeating: 0, count: n)
    for _ in 0..<d%8 {
        
        for i in 0..<n { // step 1
            temp[i] = arr[i][n/2]
            arr[i][n/2] = arr[i][i]
        }
        
        for i in 0..<n { // step 2
            (temp[i], arr[i][n-1 - i]) = (arr[i][n-1 - i], temp[i])
        }
        
        for i in 0..<n { // step 3
            (temp[i], arr[n/2][n-1 - i]) = (arr[n/2][n-1 - i], temp[i])
        }
        
        for i in 0..<n { // step 4
            (temp[i], arr[n-1 - i][n-1 - i]) = (arr[n-1 - i][n-1 - i], temp[i])
        }
    }
    
    // 결과 출력
    for i in 0..<n {
        for j in 0..<n {
            print(arr[i][j], terminator: " ")
        }
        print()
    }
}
