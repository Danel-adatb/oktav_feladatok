import "../App.css";
import {Link} from "react-router-dom";


function Index() {
    return (
        <>
            <div id="nyito">
                <header>
                    <Link to="/index">
                        <img
                            src="/public/assets/sunflower.jpg"
                            alt="fa"
                            id="logo"
                        />
                    </Link>

                    <h1>Nevenincs Bt.</h1>
                    <h2>Vetőmagok - Mindenféle, minden mennyiségben</h2>
                </header>
                <main>
                    <Link to={"/aruk"}>
                        <a>Válasszon vetőmagjainkból!</a>
                    </Link>
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

export default Index;