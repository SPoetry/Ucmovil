<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateHorariosTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('horarios', function (Blueprint $table) {
            $table->string('id_asignatura', 10);
            $table->integer('modulo');
            $table->string('dia', 10);
            $table->string('sala', 10);
            $table->timestamps();
            $table->primary(['id_asignatura', 'dia', 'modulo']);
            $table->foreign('id_asignatura')->references('id_asignatura')->on('asignaturas');
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('horarios');
    }
}
