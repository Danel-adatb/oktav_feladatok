import "../App.css"
import {Link} from "react-router-dom";

function Aruk() {
    return (
        <>
            <div>
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
                <main className={"container"}>
                    <div className="row">
                        <h2>Vetőmagjaink:</h2>
                        <div className="col-lg-4 mt-4 arukep">
                            <h4>Dália</h4>
                            <Link to="/megrendeles">
                                <img src="../../public/assets/dalia.jpg" alt="Dália" className="img-fluid"/>
                            </Link>
                        </div>
                        <div className="col-lg-4 mt-4 arukep">
                            <h4>Százszorszép</h4>
                            <img src="../../public/assets/szazszorszep.jpg" alt="Százszorszép" className="img-fluid"/>
                        </div>
                        <div className="col-lg-4 mt-4 arukep">
                            <h4>Levendula</h4>
                            <img src="../../public/assets/levendula.jpg" alt="Levendula" className="img-fluid"/>
                        </div>
                        <div className="col-lg-4 mt-4 arukep">
                            <h4>Petúnia</h4>
                            <img src="../../public/assets/petunia.jpg" alt="Petúnia" className="img-fluid"/>
                        </div>
                        <div className="col-lg-4 mt-4 arukep">
                            <h4>Bazsalikom</h4>
                            <img src="../../public/assets/bazsalikom.jpg" alt="Bazsalikom" className="img-fluid"/>
                        </div>
                        <div className="col-lg-4 mt-4 arukep">
                            <h4>Rozmaring</h4>
                            <img src="../../public/assets/rozmaring.jpg" alt="Rozmaring" className="img-fluid"/>
                        </div>
                        <div className="col-lg-4 mt-4 arukep">
                            <h4>Paradicsom</h4>
                            <img src="../../public/assets/paradicsom.jpg" alt="Paradicsom" className="img-fluid"/>
                        </div>
                        <div className="col-lg-4 mt-4 arukep">
                            <h4>Sárgarépa</h4>
                            <img src="../../public/assets/sargarepa.jpg" alt="Sárgarépa" className="img-fluid"/>
                        </div>
                        <div className="col-lg-4 mt-4 arukep">
                            <h4>Karalábé</h4>
                            <img src="../../public/assets/karalabe.jpg" alt="Karalábé" className="img-fluid"/>
                        </div>
                        <div className="col-lg-4 mt-4 arukep">
                            <h4>Szamóca</h4>
                            <img src="../../public/assets/szamoca.jpg" alt="Szamóca" className="img-fluid"/>
                        </div>
                        <div className="col-lg-4 mt-4 arukep">
                            <h4>Málna</h4>
                            <img src="../../public/assets/malna.jpg" alt="Málna" className="img-fluid"/>
                        </div>
                        <div className="col-lg-4 mt-4 arukep">
                            <h4>Chili paprika</h4>
                            <img src="../../public/assets/chili-paprika.jpg" alt="Chili paprika" className="img-fluid"/>
                        </div>
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

export default Aruk