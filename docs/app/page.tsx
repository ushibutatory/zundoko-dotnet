"use client";

import React from "react";
import styles from "./page.module.scss";
import Nav from "@/components/nav";
import ResultView from "@/components/resultView";
import ISong from "@/models/ISong";
import IResult from "@/models/IResult";
import ZundokoService from "@/services/zundokoService";

export default function Page() {
  const [songs, setSongs] = React.useState<ISong[]>();
  const [selectedSong, setSelectedSong] = React.useState<ISong>();
  const [result, setResult] = React.useState<IResult>();

  // 初期表示時
  React.useEffect(() => {
    const service = new ZundokoService();
    (async () => {
      try {
        setSongs(await service.list());
      } catch (e) {
        console.log(e);
      }
    })();
  }, []);

  // 歌選択時
  const onChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    const song = songs?.find((_) => _.PlayName === event.target.value);
    setSelectedSong(song);
  };

  // 実行時
  const onClick = async () => {
    if (!selectedSong) return;

    const service = new ZundokoService();
    setResult(await service.play(selectedSong.PlayName));
  };

  return (
    <main className={styles.main}>
      <Nav />
      <div className="container">
        <div className={styles.explain}>
          <p>歌詞が完成するまでランダムにフレーズを出力します。</p>
        </div>
        <div className="row">
          <div className="col-md-6">
            <legend>やってみよう！</legend>
            <table>
              <tbody>
                <tr>
                  <th>
                    <span className="form-label">曲 (Song)</span>
                  </th>
                  <td>
                    <select className="form-select" onChange={(_) => onChange(_)}>
                      <option value=""></option>
                      {songs?.map((_) => {
                        return (
                          <option key={_.PlayName} value={_.PlayName}>
                            {_.Title}
                          </option>
                        );
                      })}
                    </select>
                  </td>
                </tr>
              </tbody>
            </table>
            <div className={styles.run}>
              <button className="btn btn-primary" onClick={onClick} disabled={!selectedSong}>
                {selectedSong ? "Let's GO!" : "歌を選んでね"}
              </button>
            </div>
          </div>
          <div className="col-md-6">{!result ? <></> : ResultView(result)}</div>
        </div>
      </div>
    </main>
  );
}
