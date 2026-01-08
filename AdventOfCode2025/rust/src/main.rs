use std::time::{SystemTime};

mod day1;

fn main() {
    let mut day = String::new();
    std::io::stdin().read_line(&mut day).expect("Should have been able to read from stdin");

    let timer = SystemTime::now();
    let day = day.trim();
    match day{
        "1" => {day1::solution1(&timer); day1::solution2(&timer);},
        _ => {println!("Day not found");return}
    }
    if let Ok(duration) = timer.elapsed(){
        let sec = duration.as_secs();
        println!("Time to compute day{day}: {sec} sec")
    } else {
        println!("Error calculating the time");
        return
    };
}
