import "../App.css"
import {Link, useNavigate} from "react-router-dom";
import {useEffect, useState} from "react";

function Flowers() {
    const [data, setData] = useState([]);
    const navigate  = useNavigate();

    useEffect(() => {
        fetch("https://localhost:7131/api/flowers")
            .then(res => {
                if(!res.ok) {
                    throw new Error(`HTTP error: ${res.status}`);
                }

                return res.json();
            })
            .then(data => {
                console.log("Flowers:", data);
                setData(data);
            })
            .catch(error => {
                console.error("Fetch error:", error);
            });
    }, []);

    return (
        <>
            <div>
                <header>
                    <Link to="/">
                        <img
                            src="/public/assets/sunflower.jpg"
                            alt="fa"
                            id="logo"
                        />
                    </Link>
                    <h1>Nevenincs Bt.</h1>
                    <h2>Vetőmagok - Mindenféle, minden mennyiségben</h2>
                </header>
                <main className={"container"}>
                    <div className="row">
                        <h2>Vetőmagjaink:</h2>
                        {data.map((item) => (
                            <div className="col-lg-4 mt-4 arukep" key={item.id}>
                                <h4>{item.pName}</h4>
                                <img
                                    src={item.imgUrl}
                                    alt={item.pName}
                                    className="img-fluid"
                                    onClick={() => navigate(`/rendeles/${item.id}`)}
                                />
                            </div>
                        ))}
                    </div>
                </main>
                <footer className="container-fluid">
                    <div className="row">
                        <div className="col-md-2 col-lg-2">
                            <h3>Nyitvatartás:</h3>
                        </div>

                        <div className="col-md-4 col-lg-4">
                            <ul>
                                <li>Hétfő-Péntek: 8-17 óráig</li>
                                <li>Szombat: 8-13 óráig</li>
                                <li>Vasárnap: 9-12 óráig</li>
                            </ul>
                        </div>

                        <div className="col-md-2 col-lg-2">
                            <h3>Kapcsolat:</h3>
                        </div>

                        <div className="col-md-4 col-lg-4">
                            <ul>
                                <li>06-30/111-1111</li>
                                <li>06-70/111-1111</li>
                                <li>nevenincsbt@gmail.com</li>
                            </ul>
                        </div>
                    </div>
                </footer>
            </div>
        </>
    );
}

export default Flowers