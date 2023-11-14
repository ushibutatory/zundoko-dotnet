import styles from "@/components/resultView.module.scss";
import IResult from "@/models/IResult";

const ResultView = (result: IResult) => {
  console.log(result);

  const phrases = result.SingerPhrases.map((_, index) => {
    const inlineStyle = {
      paddingLeft: `${Math.random() * 0.5}rem`,
      paddingRight: `${Math.random() * 0.5}rem`,
    };
    const phraseView = (
      <span key={`${index}-${_}`} className={styles.singerPhrase} style={inlineStyle}>
        {_}
      </span>
    );
    return phraseView;
  });

  return (
    <>
      {phrases}
      {result.IsSucceed ? (
        <div className={styles.audiencePhrase}>{result.AudiencePhrase}</div>
      ) : (
        <div className={styles.message}>{result.Message}</div>
      )}
    </>
  );
};

export default ResultView;
