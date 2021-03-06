function reverseString(s) {
    return s.split("").reverse().join("");
}

const token_api = reverseString("dd5581b6590ea5d1809b1d14ab37b5e9beaf60d8");
const github_url = "https://api.github.com"
var converter = new showdown.Converter();

let basicInformation = {};
const getbasicInformation = () => {
    axios.get(`${github_url}/repos/fga-gpp-mds/2018.1-Reabilitacao-Motora`, {
        headers: {
            Authorization: `token ${token_api}`
        }
    })
        .then(function (response) {
            basicInformation = response.data;
            setBasicDynamicData();
        }).catch(function (error) {
            console.log(error);
        });
}

const setBasicDynamicData = () => {

    //forks
    let forks = document.getElementById("forks");
    forks.classList.remove("loader");
    forks.innerHTML = "Número total de forks: " + basicInformation.forks_count;


    //language
    let language = document.getElementById("language");
    language.classList.remove("loader");
    language.innerHTML = basicInformation.language;

    //issues
    let issues = document.getElementById("issues");
    issues.classList.remove("loader");
    issues.innerHTML = basicInformation.open_issues;

}

let statisticInfo = {};
const getStatisticInfo = () => {
    axios.get(`${github_url}/repos/fga-gpp-mds/2018.1-Reabilitacao-Motora/stats/contributors`, {
        headers: {
            Authorization: `token ${token_api}`
        }
    })
        .then(function (response) {
            statisticInfo = response.data;
            setTopCommiter();
        }).catch(function (error) {
            console.log(error);
        });
}


const setTopCommiter = () => {
    let topCommit = -1;
    let topCommitter = "";
    let topLines = 0;
    let topAvatar = "";
    for (let user in statisticInfo) {
        if (statisticInfo[user].weeks.slice(-2)[0].c > topCommit) {
            topCommit = statisticInfo[user].weeks.slice(-2)[0].c;
            topCommitter = statisticInfo[user].author.login;
            topLines = statisticInfo[user].weeks.slice(-2)[0].a + statisticInfo[user].weeks.slice(-2)[0].d;
            topAvatar = statisticInfo[user].author.avatar_url;
        }
    }
    let div = document.getElementById("top-committer");
    let avatar = document.getElementById("top-avatar");
    let divCommmit = document.getElementById("top-commit");
    let divLines = document.getElementById("top-lines");
    let divLink = document.getElementById("top-link");

    div.innerHTML = topCommitter + `<i class="material-icons right">more_vert</i>`;
    divCommmit.innerHTML = "Número de commits: " + topCommit;
    divLines.innerHTML = "Número de linhas: " + topLines;
    avatar.src = topAvatar;
    divLink.href = `https://github.com/${topCommitter}`;
}

let totalCommits = [];
const getCommits = (pageCounter) => {
    axios.get(`${github_url}/repos/fga-gpp-mds/2018.1-Reabilitacao-Motora/commits?page=${pageCounter}`, {
        headers: {
            Authorization: `token ${token_api}`
        }
    })
        .then(function (response) {
            if (response.data.length !== 0) {
                totalCommits.push(response.data);
                getCommits(pageCounter + 1);
            } else {
                setCommitData();
            }
        }).catch(function (error) {
            console.log(error);
        });
}

const setCommitData = () => {
    let commits = document.getElementById("commits");
    let counter = 0;
    for (let commit in totalCommits) {
        counter += totalCommits[commit].length;
    }
    commits.classList.remove("loader");
    commits.innerHTML = "Número total de commits: " + counter;

    const template = (author, message, date, avatar_url) => {
        return (
            `
                <li class="collection-item avatar">
                    <img src="${avatar_url}" alt="" class="circle">
                    <span class="title">${author}</span>
                    <p>${message}
                        <br> ${date}
                    </p>
                </li>
            `
        )
    }

    for (let i = 0; i < 5; i++) {
        let author = totalCommits[0][i].commit.author.name;
        let message = totalCommits[0][i].commit.message;
        let date = totalCommits[0][i].commit.author.date;
        let avatar_url = totalCommits[0][i].author.avatar_url;
        let list = document.getElementById("project-list");
        let oneElement = document.createElement("li");
        oneElement.className = "project-item";
        oneElement.innerHTML = template(author, message, date, avatar_url);
        list.appendChild(oneElement);
    }

}

let commitsPerDay = [];
const getCommitPerDay = () => {
    axios.get(`${github_url}/repos/fga-gpp-mds/2018.1-Reabilitacao-Motora/stats/commit_activity`, {
        headers: {
            Authorization: `token ${token_api}`
        }
    })
        .then(function (response) {
            commitsPerDay = response.data;
            startChart();
        }).catch(function (error) {
            console.log(error);
        });
}


const startChart = () => {
    let commitData = [];
    for (let i = 5; i >= 1; i--) {
        let time = new Date((commitsPerDay.slice(-i)[0].week) * 1000)
        let week = { commits: commitsPerDay.slice(-i)[0].total, start: time }
        commitData.push(week);
    }

    let ctx = document.getElementById("commit-chart").getContext('2d');
    document.getElementById("commit-chart").classList.remove("big-loader");
    let myChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: [
                commitData[0].start.toString().substring(4, 15),
                commitData[1].start.toString().substring(4, 15),
                commitData[2].start.toString().substring(4, 15),
                commitData[3].start.toString().substring(4, 15),
                commitData[4].start.toString().substring(4, 15)
            ],
            datasets: [{
                label: 'Commits/Semana',
                data: [
                    commitData[0].commits,
                    commitData[1].commits,
                    commitData[2].commits,
                    commitData[3].commits,
                    commitData[4].commits
                ],
                backgroundColor: [
                    '#0984e3'
                ],
                borderColor: [
                    '#636e72'
                ],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });
}

let releases = [];
const getReleases = () => {
    axios.get(`${github_url}/repos/fga-gpp-mds/2018.1-Reabilitacao-Motora/releases`, {
        headers: {
            Authorization: `token ${token_api}`
        }
    })
        .then(function (response) {
            releases = response.data;
            console.log(releases);
            setReleases();
        }).catch(function (error) {
            console.log(error);
        });
}

const setReleases = () => {
    for (i in releases) {
        let releaseHtml =
        `
            <h4 style="text-align:center;">${releases[i].name} - ${releases[i].tag_name}</h4>
            <p>${converter.makeHtml(releases[i].body)}</p>
        `
        let carousel = document.getElementById('main-carousel');
        let release = document.createElement('div');
        release.className = 'carousel';
        release.innerHTML = releaseHtml
        carousel.appendChild(release);
    }

    $(document).ready(function () {
        $(".owl-carousel").owlCarousel({
            margin:10,
            items:4
        });
    });

    $('.nonloop').owlCarousel({
        center: true,
        items:2,
        loop:false,
        margin:10,
        responsive:{
            600:{
                items:4
            }
        }
    });


}


window.onload = () => {
    getbasicInformation();
    getStatisticInfo();
    getCommits(1);
    getCommitPerDay();

    getDocumentsInfo();

    getRepoDocInfo();

    getReleases();
}
